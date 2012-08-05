Include ".\build_utils.ps1"

properties {
	$base_dir  = resolve-path .
	$bin_dir = "$base_dir\bin"
	$src_dir = "$base_dir\src"
	$config_dir = "$base_dir\config"
	$packages_dir = "$base_dir\src\packages"
	$nuget_exe = "$src_dir\.nuget\NuGet.exe"
}

Task default -Depends Test

Task Clean {
   "clean"
}

Task Init -depends Clean {
   "init"
}

Task Compile -Depends Init {
   "compile"
}

Task Test -Depends Compile {
	"This is a test"
}

Task Release {
	
}

Task RunDB {
	$ravenServerPackageFolder = Get-ChildItem "$packages_dir\RavenDB.Server.*" | 
										Sort-Object Name -Descending | 
										Select-Object -First 1
										
	$ravenServerFolder = "$ravenServerPackageFolder\tools"
	
	Copy-Item "$config_dir\RavenDB-DeveloperMachine.config" "$ravenServerFolder\Raven.Server.exe.config"
	
	$developerRavenProcess = Start-Process "$ravenServerFolder\Raven.Server.exe" "--config=$config_dir\RavenDB-DeveloperMachine.config" -PassThru
}

Task ExportData {
	$dump_dir = "$bin_dir\DataDumps"
	$dump_dir
	New-Item $dump_dir -Type Directory -ErrorAction SilentlyContinue | Out-Null
	
	$smuggler = "C:\RavenDB\Smuggler\Raven.Smuggler.exe"
	. $smuggler out http://localhost:8080/ "$dump_dir\Documents.dump.zip" --database=Binah --operate-on-types=Documents
}