param($rootPath, $toolsPath, $package, $project)

# Note that as of NuGet 1.0, the init.ps1 scripts run in an undefined order, 
# so this script must not depend on T4Scaffolding already being initialized.

function LoadAssemblyWithShadowCopy($assemblyPath) {
	# Temporary manual kind of shadow copying so the package can be uninstalled
	$global:mvcScaffoldingDllsPath = Join-Path $env:temp ("ScaffoldShadow_" + [System.Guid]::NewGuid().ToString())
	md $global:mvcScaffoldingDllsPath

	$folderToShadow = [System.IO.Path]::GetDirectoryName($assemblyPath)
	$fileToShadow = [System.IO.Path]::GetFileName($assemblyPath)
	Copy-Item (Join-Path $folderToShadow "*.dll") $global:mvcScaffoldingDllsPath
	Import-Module (Join-Path $global:mvcScaffoldingDllsPath $fileToShadow)
}

# Simplistic tab expansion
if (!$global:scaffolderTabExpansion) { $global:scaffolderTabExpansion = @{ } }
$global:scaffolderTabExpansion["MvcScaffolding.RazorView"] = $global:scaffolderTabExpansion["MvcScaffolding.AspxView"] = {
	param($filter, $allTokens)
	$secondLastToken = $allTokens[-2]
	if (($secondLastToken -eq 'ViewName') -or ($allTokens.Length -eq 3)) {
		return @("Create", "Delete", "Details", "Edit", "Index")
	}
}

LoadAssemblyWithShadowCopy(Join-Path $toolsPath "MvcScaffolding.dll")