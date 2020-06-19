Steps to release a new version of CrossTest:
1. Updated the version numbers of the assemblies in visual studio on all 3 projects.
2. Set the build to 'Release' and perform a rebuild all.
3. Updated the CrossBreeze_CrossTest_SpecFlow/CrossBreeze.CrossTest.SpecFlow.nuspec
     - Update the version number.
     - Update the release notes.
4. Execute the CreateNuPkg.cmd file.
5. Update the PushNuPkg.cmd to the right version.
6. Execute the PushNuPkg.cmd file.