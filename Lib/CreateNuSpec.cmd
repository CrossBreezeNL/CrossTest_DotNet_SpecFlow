@echo off

echo Don't continue if you don't want to update the .nuspec file.
pause

cd ./CrossBreeze_CrossTest_SpecFlow

call nuget spec CrossBreeze.CrossTest.SpecFlow.csproj

pause
