[T4Scaffolding.Scaffolder(Description = "Creates an entirely new scaffolder with a PS1 script and a T4 template")][CmdletBinding()]
param(        
    [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$CustomScaffolderName,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$templateName = $CustomScaffolderName + "Template"

# PS1 script
$customScaffoldersPath = [T4Scaffolding.Core.ScaffoldingConstants]::CustomScaffoldersFolderPath
$outputPath = Join-Path (Join-Path $customScaffoldersPath $CustomScaffolderName) $CustomScaffolderName
$templateFile = Find-ScaffolderTemplate DefaultPs1Script -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage "ps1"
$wroteFile = Invoke-ScaffoldTemplate -Template $templateFile -Model @{ Scaffolder = $CustomScaffolderName; TemplateName = $templateName } -Project $Project -OutputPath $outputPath -Force:$Force 
if($wroteFile) {
	Write-Host "Added scaffolder script '$wroteFile'"
}

# T4 template
$outputPath = Join-Path (Join-Path $customScaffoldersPath $CustomScaffolderName) $templateName
$templateFile = Find-ScaffolderTemplate DefaultT4Template -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage
$wroteFile = Invoke-ScaffoldTemplate -Template $templateFile -Model @{ } -Project $Project -OutputPath $outputPath -Force:$Force 
if($wroteFile) {
	Write-Host "Added scaffolder template '$wroteFile'"
}