@echo off

echo Pushing NuPkg file to NuGet...
SET nuget="../nuget.exe"
call %nuget% push CrossBreeze.CrossTest.Process.Ssis.1.1.0.nupkg oy2j7texy3cmructaiyanl6zeve44hau5p4w2hcqfwkgzm -Source https://api.nuget.org/v3/index.json
echo Done.

pause