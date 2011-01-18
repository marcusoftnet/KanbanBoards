param($rootPath, $toolsPath, $package, $project)

$nugetVersion = [NuGet.PackageManager].Assembly.GetName().Version.ToString()
if (!$nugetVersion.StartsWith("1.0.")) {
	Write-Warning "T4Scaffolding currently requires NuGet version 1.0. You are running version $nugetVersion. Scaffolding will be disabled."
	return
}

$dllPath = Join-Path $toolsPath T4Scaffolding.dll
$tabExpansionPath = Join-Path $toolsPath "scaffoldingTabExpansion.psm1"

if (Test-Path $dllPath) {
	# Temporary manual kind of shadow copying so the package can be uninstalled
	$tempDllFolder = Join-Path $env:temp ("ScaffoldShadow_" + [System.Guid]::NewGuid().ToString())
	md $tempDllFolder
	Copy-Item (Join-Path $toolsPath "*.dll") $tempDllFolder
	$dllPath = Join-Path $tempDllFolder T4Scaffolding.dll

	# First import the module into the local scope where init.ps1 runs...
	Import-Module $dllPath
	Set-Alias Scaffold Invoke-Scaffolder -Option AllScope -scope Global
	Update-FormatData -PrependPath (Join-Path $toolsPath T4Scaffolding.Format.ps1xml)

	# ...then promote it to global scope. Note that this is a workaround for the fact that NuGet doesn't
	# currently have a native way for packages to export PowerShell module members into the Package
	# Manager Console scope. When this is resolved in a future version of NuGet, there will be no further
	# need for GlobalCommandRunner and it will be removed. Don't call it from your own package!
	[T4Scaffolding.Cmdlets.GlobalCommandRunner]::Run("Import-Module -Force -Global ""$dllPath""; Set-Alias Scaffold Invoke-Scaffolder -Option AllScope -scope Global; Import-Module -Force -Global ""$tabExpansionPath""", $true)
} else {
	Write-Warning ("Could not find T4Scaffolding module. Looked for: " + $dllPath)
}