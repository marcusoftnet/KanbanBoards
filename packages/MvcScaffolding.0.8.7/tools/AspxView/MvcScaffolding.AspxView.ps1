[T4Scaffolding.Scaffolder(Description = "Adds an ASP.NET MVC view using the ASPX view engine")][CmdletBinding()]
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

# Inherit all logic from MvcScaffolding.RazorView (merely override the templates)
Scaffold MvcScaffolding.RazorView -ViewName $ViewName -ModelType $ModelType -Area $Area -Layout $Layout -Project $Project -CodeLanguage $CodeLanguage -Force:$Force -OverrideTemplateFolders $TemplateFolders