@echo off

SET nuget="../nuget.exe"
call %nuget% pack ./CrossBreeze.CrossTest.Process.Ssis.nuspec

pause
