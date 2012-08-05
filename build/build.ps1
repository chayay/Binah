param($task = "default")

$scriptPath = $MyInvocation.MyCommand.Path
$scriptDir = Split-Path $scriptPath

get-module psake | remove-module

import-module (Get-ChildItem "$scriptDir\..\src\packages\psake.*\tools\psake.psm1" | Select-Object -First 1)

invoke-psake "$scriptDir\tasks.ps1" $task