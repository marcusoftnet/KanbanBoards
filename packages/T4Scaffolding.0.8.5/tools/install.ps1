param($rootPath, $toolsPath, $package, $project)

# Bail out if scaffolding is disabled (probably because you're running an incompatible version of NuGet)
if (-not (Get-Command Invoke-Scaffolder)) { return }

if ($project) { $projectName = $project.Name }
Get-ProjectItem "InstallationDummyFile.txt" -Project $projectName | %{ $_.Delete() }

Set-DefaultScaffolder -Name DbContext -Scaffolder T4Scaffolding.EFDbContext -SolutionWide -DoNotOverwriteExistingSetting
Set-DefaultScaffolder -Name Repository -Scaffolder T4Scaffolding.EFRepository -SolutionWide -DoNotOverwriteExistingSetting
Set-DefaultScaffolder -Name CustomTemplate -Scaffolder T4Scaffolding.CustomTemplate -SolutionWide -DoNotOverwriteExistingSetting
Set-DefaultScaffolder -Name CustomScaffolder -Scaffolder T4Scaffolding.CustomScaffolder -SolutionWide -DoNotOverwriteExistingSetting
