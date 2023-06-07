@echo off

echo Pushing NuPkg file to NuGet...
call nuget push CrossBreeze.CrossTest.1.1.1.nupkg oy2jruzc3jfpdi5jduiq5ycq5xjcqdjuvddqehxy3dvrwq -Source https://api.nuget.org/v3/index.json
echo Done.

pause