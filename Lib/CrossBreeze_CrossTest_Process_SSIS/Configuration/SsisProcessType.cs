using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.Process.Ssis.Configuration
{
    public enum SsisProcessType
    {
        [XDoc(
            Title = "Integration Services server",
            Description = "This type is used to execute a package stored in the SSISDB catalog (Project deployment model)."
        )]
        ISServer,

        [XDoc(
            Title = "SQL Server Integration Services project deployment file",
            Description = "This type is used to execute a package stored in a IsPac file (Project deployment model)."
        )]
        ISPac,

        [XDoc(
            Title = "SQL Server package",
            Description = "This type is used to execute a package stored in msdb database (Package deployment model)."
        )]
        SqlServer,

        [XDoc(
            Title = "SSIS Package Store",
            Description = "This type is used to execute a package stored in the SSIS Package Store (Package deployment model)."
        )]
        SsisPackageStore,

        [XDoc(
            Title = "File System",
            Description = "This type is used to execute a package stored on the file system (Package deployment model)."
        )]
        FileSystem
    }
}
