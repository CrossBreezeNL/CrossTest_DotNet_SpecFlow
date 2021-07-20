@echo off

echo Pushing NuPkg file to NuGet...
call nuget push CrossBreeze.CrossTest.1.0.2.2.nupkg oy2phxtj2ms7fv3yb2yq6bdpvlwxtn4unepkzwfrlfqpq4 -Source https://api.nuget.org/v3/index.json
echo Done.

pause