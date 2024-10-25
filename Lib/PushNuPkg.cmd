@echo off

echo Pushing NuPkg file to NuGet...
call nuget push CrossBreeze.CrossTest.1.1.3.nupkg API_KEY -Source https://api.nuget.org/v3/index.json
echo Done.

pause