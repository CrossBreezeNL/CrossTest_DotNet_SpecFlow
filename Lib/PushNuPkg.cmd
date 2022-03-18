@echo off

echo Pushing NuPkg file to NuGet...
call nuget push CrossBreeze.CrossTest.1.0.2.3.nupkg oy2mitkscdidfwvvp3fagbs64hq3z26ulkeujn2ngohawa -Source https://api.nuget.org/v3/index.json
echo Done.

pause