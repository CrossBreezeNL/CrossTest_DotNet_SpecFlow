@echo off
nuget pack ./CrossBreeze.CrossTest.SpecFlow.nuspec
nuget pack ./CrossBreeze_CrossTest_Process_Adf/CrossBreeze.CrossTest.Process.Adf.nuspec
nuget pack ./CrossBreeze_CrossTest_Process_Ssis/CrossBreeze.CrossTest.Process.Ssis.nuspec
echo "Pausing before pushing packages to Nuget. Press CTRL+C to cancel."
pause
nuget push ./CrossBreeze.CrossTest.1.1.2.nupkg oy2jruzc3jfpdi5jduiq5ycq5xjcqdjuvddqehxy3dvrwq -Source https://api.nuget.org/v3/index.json
nuget push ./CrossBreeze.CrossTest.Process.Adf.1.1.2.nupkg oy2jruzc3jfpdi5jduiq5ycq5xjcqdjuvddqehxy3dvrwq -Source https://api.nuget.org/v3/index.json
nuget push ./CrossBreeze.CrossTest.Process.Ssis.1.1.2.nupkg oy2jruzc3jfpdi5jduiq5ycq5xjcqdjuvddqehxy3dvrwq -Source https://api.nuget.org/v3/index.json
