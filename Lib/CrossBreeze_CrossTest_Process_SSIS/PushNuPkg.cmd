@echo off

echo Pushing NuPkg file to NuGet...
SET nuget="../nuget.exe"
call %nuget% push CrossBreeze.CrossTest.Process.Ssis.1.1.1.nupkg oy2jruzc3jfpdi5jduiq5ycq5xjcqdjuvddqehxy3dvrwq -Source https://api.nuget.org/v3/index.json
echo Done.

pause