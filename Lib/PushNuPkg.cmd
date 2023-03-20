@echo off

echo Pushing NuPkg file to NuGet...
call nuget push CrossBreeze.CrossTest.1.0.2.3.nupkg oy2j7texy3cmructaiyanl6zeve44hau5p4w2hcqfwkgzm -Source https://api.nuget.org/v3/index.json
echo Done.

pause