# CrossTest .NET SpecFlow
This repository contains the .NET SpecFlow implementation of CrossTest. For more information on CrossTest and the supported steps see [x-test.nl](http://x-test.nl).

## Folder structure
Below the folder structure of the project is explained.

- CrossTestDocumenter
  - A C# project with which you can generate documentation model files from all XDoc annotations in the config for Core, Ssis and Adf projects. The model file can be used to generate the configuration documentation in the [Documentation/docs/Configuration](./Documentation/docs/Configuration/) folder.
- Documentation
  - The documentation of this project written in Markdown and generated to html using MkDocs. Parts of the documentation is generated (Configuration & Steps) using the generator setup in the [CrossTest](https://dev.azure.com/x-breeze/CrossTest/_git/CrossTest) repository.
- Examples
  - Examples of applying CrossTest .NET SpecFlow. This also contains a sample for each supperted step, which is the unit test for the step.
- FirstCrossTestProject
  - A sample C# library project which uses the published CrossTest packages from NuGet.
- Lib
  - The actual implementation of CrossTest .NET SpecFlow. The implementation consists of different C# projects (in different folders).
- PowerCenterTester
  - A playground implementation of PowerCenter client in C#. This could be integrated in CrossTest in the future as a new supported process, if needed. Otherwise it can be removed.

## Local testing
In order to run the tests locally (in the [CrossBreeze_CrossTest_ExampleTests](./Examples/CrossBreeze_CrossTest_ExampleTests/) project) you need to setup your environment. Following the instructions below per subject to setup you machine.

### Run PowerShell scripts.
In order to run PowerShell scripts you need to set the execution policy to Unrestricted. For this you can execute the following command in a PowerShell session on your machine.

```powershell
Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope CurrentUser
```

### Run SQL Server
For testing steps with SQL Server we use a [Docker](https://www.docker.com/) container run locally (or in the build pipeline). To create/start the SQL Server contain execute the [sqlserver_server.ps1](./Examples/CrossBreeze_CrossTest_ExampleTests/sqlserver_server.ps1) in the Examples/CrossBreeze_CrossTest_ExampleTests/ folder script.

### Run SSIS packages
In order to run SSIS packages locally, you need SQL Server Client Tools SDK. To install this on you machine you can download [SQL Server 2019 Developer Edition](https://download.microsoft.com/download/7/c/1/7c14e92e-bdcb-4f89-b7cf-93543e7112d1/SQLServer2019-x64-ENU-Dev.iso), mount the iso and install SQL Server instance with only Client Tools SDK as a feature (you don't need to install any other featuee, like the database engine).