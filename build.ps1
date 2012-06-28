param($task = "default")

get-module psake | remove-module

import-module (Get-ChildItem .\src\packages\psake.*\tools\psake.psm1 | Select-Object -First 1)

invoke-psake .\tasks.ps1 $task