@echo off

echo Don't continue if you don't want to update the .nuspec file.
pause

SET nuget="../nuget.exe"

call %nuget% spec CrossBreeze.CrossTest.Process.Ssis.csproj

pause
