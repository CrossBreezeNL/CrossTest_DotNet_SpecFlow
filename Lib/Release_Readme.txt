Steps to release a new version of CrossTest:
1. Updated the version numbers of the assemblies in visual studio on all 3 manual projects.
2. Set the build to 'Release' and perform a rebuild all.
3. update the version number in the template project for generating the specflow_steps project by editing the properties/assemblyinfo.cs file
4. regenerate the specflow_steps project, this also triggers a release build referencing the dlls built in step 1

5. Updated the CrossBreeze.CrossTest.SpecFlow.nuspec
     - Update the version number.
     - Update the release notes.
6. Execute the CreateNuPkg.cmd file.
7. Update the PushNuPkg.cmd to the right version.
8. Execute the PushNuPkg.cmd file.