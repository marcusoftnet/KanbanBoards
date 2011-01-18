[T4Scaffolding.Scaffolder(Description = "Adds ASP.NET MVC views for Create/Read/Update/Delete/Index scenarios")][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,      
	[string]$Area,
	[alias("MasterPage")][string]$Layout,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[string]$ViewScaffolder = "View",
	[switch]$Force = $false
)

@("Create", "Edit", "Delete", "Details", "Index") | %{
	Scaffold $ViewScaffolder $_ -ModelType $ModelType -Area $Area -Layout $Layout -Project $Project -CodeLanguage $CodeLanguage -OverrideTemplateFolders $TemplateFolders -Force:$Force
}