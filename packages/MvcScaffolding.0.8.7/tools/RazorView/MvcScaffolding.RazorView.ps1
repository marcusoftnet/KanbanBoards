[T4Scaffolding.Scaffolder(Description = "Adds an ASP.NET MVC view using the Razor view engine")][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ViewName,       
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,      
	[string]$Area,
	[alias("MasterPage")][string]$Layout,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

if (!((Get-ProjectAspNetMvcVersion -Project $Project) -ge 3)) {
	Write-Error ("Project '$((Get-Project $Project).Name)' is not an ASP.NET MVC 3 project.")
	return
}

$foundModelType = Get-ProjectType $ModelType -Project $Project
if (!$foundModelType) { return }

# We don't create areas here, so just ensure that if you specify one, it already exists
if ($Area) {
	$areaPath = Join-Path Areas $Area
	if (-not (Get-ProjectItem $areaPath -Project $Project)) {
		Write-Error "Cannot find area '$Area'. Make sure it exists already."
		return
	}
}

# Find the T4 template
$templateFile = Find-ScaffolderTemplate $ViewName -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -ErrorIfNotFound

if ($templateFile) {	
	# Decide where to put the output
	$outputExtension = Get-TemplateOutputExtension -Template $templateFile -Project $Project
	$outputFolderName = Join-Path Views $foundModelType.Name
	if ($Area) {
		$outputFolderName = Join-Path Areas (Join-Path $Area $outputFolderName)
	}
	$outputFileName = Join-Path $outputFolderName ($ViewName + $outputExtension)
	$existingProjectItem = Get-ProjectItem $outputFileName -Project $Project
	if ($existingProjectItem -and -not $Force) {
		Write-Warning "$outputFileName already exists! Skipping..."
		return
	}

	$addViewAppDomain = [System.AppDomain]::CreateDomain("AddViewAppDomain")
	$addViewTool = $addViewAppDomain.CreateInstanceFromAndUnwrap([MvcScaffolding.MvcTooling.AddViewTool].Assembly.Location, [MvcScaffolding.MvcTooling.AddViewTool].FullName)
	$vsProject = Get-Project $Project
    $addViewTool.TemplateFile = $templateFile
    $addViewTool.ViewName = $ViewName        
    $addViewTool.IsContentPage = [bool]$Layout
    $addViewTool.IsPartialView = $false
	$addViewTool.MasterPageFile = $Layout + ""
    $addViewTool.Namespace = $vsProject.Properties.Item("DefaultNamespace").Value
    $addViewTool.ViewDataTypeName = $foundModelType.FullName
	$addViewTool.ContentPlaceHolderIDs = New-Object "System.Collections.Generic.List``1[System.String]"
	$addViewTool.PrimaryContentPlaceHolderID = ""

	# Templates need to reference the T4Scaffolding assembly
	$templateAssemblyReferences = New-Object "System.Collections.Generic.List``1[System.String]"
	$templateAssemblyReferences.Add([T4Scaffolding.ScaffolderAttribute].Assembly.Location) 
	$addViewTool.TemplateAssemblyReferences = $templateAssemblyReferences

	# Reference this project's assembly, assuming it exists
	$buildDirectory = Join-Path $vsProject.Properties.Item("FullPath").Value $vsProject.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value
	$buildFilePath = Join-Path $buildDirectory $vsProject.Properties.Item("OutputFileName").Value
	$assembliesToReference = New-Object "System.Collections.Generic.List``1[System.String]"
	$assembliesToReference.Add($buildFilePath)

    # Loop over all the references and add them in case that's where the model type is
    foreach($reference in $vsProject.Object.References) {
        # If an assembly reference is unresolved (e.g. if user deletes the referenced assembly)
        # the VS project will list the path as an empty string, so we will filter it out
        if ($reference.Path) {                
            $assembliesToReference.Add($reference.Path)
        }
    }

    # Process the template
	$addViewTool.ProjectAssemblyReferences = $assembliesToReference
    $addViewResult = $addViewTool.AddView()
    [System.AppDomain]::Unload($addViewAppDomain)

	if ($addViewResult.SkippedBecauseCouldNotFindModel) {
		Write-Warning "Cannot scaffold view '$ViewName' because the model type '$($foundModelType.FullName)' could not be loaded. Ensure you have built your solution since creating or modifying that type. Skipping..."
		Write-Verbose ("Searched for type '$($foundModelType.FullName)' in assemblies " + [string]::Join(", ", $assembliesToReference))
    } elseif($addViewResult.Errors) {
        $addViewResult.Errors | Sort-Object Line | Sort-Object Column
    } else {
		if ($existingProjectItem) {
			# Just overwrite the file on disk
			$outputFileFullPath = $existingProjectItem.Properties.Item("FullPath").Value
			$addViewResult.Content | Out-File $outputFileFullPath
		} else {
			# Add the folder and file to the project & link to file on disk
			$outputFolderName = [System.IO.Path]::GetDirectoryName($outputFileName)
			Get-ProjectFolder $outputFolderName -Create -Project $Project | Out-Null
			$outputFolderItem = Get-ProjectItem $outputFolderName -Project $Project
			$outputFolderFullPath = $outputFolderItem.Properties.Item("FullPath").Value
			$outputFileFullPath = Join-Path $outputFolderFullPath ([System.IO.Path]::GetFileName($outputFileName))
			$addViewResult.Content | Out-File $outputFileFullPath
			(Get-ProjectFolder $outputFolderName -Project $Project).AddFromFile($outputFileFullPath) | Out-Null
		}
		Write-Host "Added view $outputFileName"
	}
}