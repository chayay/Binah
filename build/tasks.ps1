Include ".\build_utils.ps1"

properties {
	$base_dir  = Split-Path (resolve-path .) -parent
	$buildArtifacts_dir = "$base_dir\bin"
	$src_dir = "$base_dir\src"
	$config_dir = "$base_dir\config"
	$packages_dir = "$base_dir\src\packages"
	$nuget_exe = "$src_dir\.nuget\NuGet.exe"
	$sln_file = "$src_dir\Binah.sln"
	
	$configuration = "Release"
}

Task default -Depends Test

Task Clean {
   "clean"
}

Task Init -depends Clean {
   "init"
}

Task Compile -Depends Init {
	$msBuild = "$Env:WinDir\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
	
	Write-Host "Compiling code with '$configuration' configuration" -ForegroundColor Yellow
	exec { &$msBuild "$sln_file" /p:OutDir="$buildArtifacts_dir\" /nodeReuse:false /p:Configuration=$configuration /p:Platform="Any CPU" /verbosity:minimal /fileLogger "/fileloggerparameters:LogFile=$buildArtifacts_dir\MSBuild.log;Verbosity=Normal;Encoding=UTF-8" }
}

Task Test -Depends Compile {
	"This is a test"
}

Task Release {
	
}

Task RunDB -Depends Compile {
	$ravenServerPackageFolder = Get-ChildItem "$packages_dir\RavenDB.Server.*" | 
										Sort-Object Name -Descending | 
										Select-Object -First 1
										
	$ravenServerFolder = "$ravenServerPackageFolder\tools"
	
	Copy-Item "$config_dir\RavenDB-DeveloperMachine.config" "$ravenServerFolder\Raven.Server.exe.config"
	
	$developerRavenProcess = Start-Process "$ravenServerFolder\Raven.Server.exe" "--config=$config_dir\RavenDB-DeveloperMachine.config" -PassThru
}

Task RunWebsite -Depends RunDB {
	$iisExpress = "${Env:ProgramFiles(x86)}\IIS Express\iisexpress.exe"
	
	$apiWebsite = Start-Process "$iisExpress" "/trace:i /path:$src_dir\Binah.Web.Api /port:3001" -PassThru
	$uiWebsite = Start-Process "$iisExpress" "/trace:i /path:$src_dir\Binah.Web.UI /port:3002" -PassThru
}

Task ExportData {
	$dump_dir = "$buildArtifacts_dir\DataDumps"
	$dump_dir
	New-Item $dump_dir -Type Directory -ErrorAction SilentlyContinue | Out-Null
	
	$smuggler = "C:\RavenDB\Smuggler\Raven.Smuggler.exe"
	. $smuggler out http://localhost:8080/ "$dump_dir\Documents.dump.zip" --database=Binah --operate-on-types=Documents
}