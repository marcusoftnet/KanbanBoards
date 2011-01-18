[T4Scaffolding.Scaffolder(Description = "Enter a description of your scaffolder here")][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$DbContextType,
	[ScriptBlock]$GetPersistedTypeFromMember = {
		# For a given MemberInfo determines whether it represents a persisted property, and if so, returns the full type name of that property
		# The following code locates properties of type DbSet<...> as used by Entity Framework Code First
		param($codeMember)
		if (($codeMember.Kind -eq 4) -and ($codeMember.Type.AsFullName -match "^System.Data.Entity.DbSet(<|\(Of )(.*)(>|\))$")) {
			$matches[2]
		}
	},
	[string]$Folder,
	[string]$Area,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders
)

function GetPersistedEntityProperties($existingProjectItem) {
	if ($existingProjectItem) {
		# First look for a top-level class
		$classes = $existingProjectItem.FileCodeModel.CodeElements | ? { $_.Kind -eq 1 }
		if(!$classes) {
			# No top-level class found. Try searching inside top-level namespaces
			$classes = $existingProjectItem.FileCodeModel.CodeElements | ? { $_.Kind -eq 5 } | ForEach-Object { $_.Children | ? { $_.Kind -eq 1 } }
		}
		if(($classes | Measure-Object).Count -ne 1) {
			throw "Found existing DbContext file '$outputPath', but can't find the class it contains. If you have edited this file manually, you will need to delete the file so it can be recreated."
		}
		$classes.Members | %{
			$persistedType = (. $GetPersistedTypeFromMember $_)
			if ($persistedType) {
				@{ "Name" = $_.Name; "ModelType" = [string]$persistedType }
			}
		}
	}
}

# Ensure we can find the model type
$foundModelType = Get-ProjectType $ModelType -Project $Project
if (!$foundModelType) { return }

# Ensure we can find the template
$templateFile = Find-ScaffolderTemplate DbContext -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -ErrorIfNotFound
if ($templateFile) {

	# Determine where the output will go
	$outputPath = Join-Path Models $DbContextType
	if ($Area -and -not $Folder) {
		$Folder = Join-Path Areas $Area
		if (-not (Get-ProjectItem $Folder -Project $Project)) {
			Write-Error "Cannot find area '$Area'. Make sure it exists already."
			return
		}
	}
	if ($Folder) {
		$outputPath = Join-Path $Folder $outputPath
	}

	# Figure out what DbSets are already in the context (if it already exists)
	if (!$CodeLanguage) { $CodeLanguage = Get-ProjectLanguage -Project $Project }
	$existingProjectItem = Get-ProjectItem "$outputPath.$CodeLanguage" -Project $Project
	[Array]$properties = GetPersistedEntityProperties $existingProjectItem $properties

	# Ensure the requested model type is included in the model data
	$existingEntryForModelType = $properties | ? { $_ -and ($_["ModelType"] -eq $foundModelType.FullName) }
	if(!$existingEntryForModelType) {
		[string]$pluralizedName = Get-PluralizedWord $foundModelType.Name
		$properties += @{ "Name"=$pluralizedName; "ModelType"=$foundModelType.FullName }
	}

	# Render the DbContext template, adding the output to the Visual Studio project
	$defaultNamespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value
	$dbContextNamespace = [T4Scaffolding.Namespaces]::Normalize($defaultNamespace + "." + [System.IO.Path]::GetDirectoryName($outputPath).Replace([System.IO.Path]::DirectorySeparatorChar, "."))
	$wroteFile = Invoke-ScaffoldTemplate -Template $templateFile -Model @{ DbContextNamespace = $dbContextNamespace; DefaultNamespace = $defaultNamespace; DbContextType = $DbContextType; Properties = $properties; } -Project $Project -OutputPath $outputPath -Force
	if($wroteFile) {
		$messageVerb = if($existingProjectItem) { "Updated" } else { "Added" }
		Write-Host "$messageVerb database context '$wroteFile'"
	}
}