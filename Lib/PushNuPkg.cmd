@echo off

echo Pushing NuPkg file to NuGet...
call nuget push CrossBreeze.CrossTest.1.0.0.9.nupkg oy2nqa7byb64uwrz3cnqf64cobjiqu2evhe6o4cy5kkkqu -Source https://api.nuget.org/v3/index.json
echo Done.

pause