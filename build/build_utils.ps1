Function Get-PackagePath {
	Param([string]$packageName)
		
	$packagePath = Get-ChildItem "$packages_dir\$packageName.*" |
						Sort-Object Name -Descending | 
						Select-Object -First 1
	Return "$packagePath"
}