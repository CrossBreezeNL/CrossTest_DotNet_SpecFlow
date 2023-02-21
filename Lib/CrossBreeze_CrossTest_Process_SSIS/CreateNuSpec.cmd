@echo off

echo Don't continue if you don't want to update the .nuspec file.
pause

call nuget spec CrossBreeze.CrossTest.Process.Ssis.csproj

pause
