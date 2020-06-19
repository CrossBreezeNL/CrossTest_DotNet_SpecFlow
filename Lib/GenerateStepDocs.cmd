@echo off

cd ./CrossBreeze_CrossTest_SpecFlow

call "../packages/SpecFlow.2.4.1/tools/specflow.exe" StepDefinitionReport --ProjectFile CrossBreeze.CrossTest.SpecFlow.csproj --OutputFile CrossBreeze.CrossTest.Steps.html

pause