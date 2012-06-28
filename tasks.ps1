properties {
	$base_dir  = resolve-path .
	$bin_dir = "$base_dir\bin"
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

Task ExportData {
	$dump_dir = "$bin_dir\DataDumps"
	$dump_dir
	New-Item $dump_dir -Type Directory -ErrorAction SilentlyContinue | Out-Null
	
	$smuggler = "C:\RavenDB\Smuggler\Raven.Smuggler.exe"
	. $smuggler out http://localhost:8080/ "$dump_dir\Documents.dump.zip" --database=Binah --operate-on-types=Documents
}