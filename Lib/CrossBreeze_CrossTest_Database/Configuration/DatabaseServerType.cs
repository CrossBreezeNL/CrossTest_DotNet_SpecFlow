using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.Database.Configuration
{
    public enum DatabaseServerType
    {
        [XDoc(
            Title = "Microsoft SQL Server Database"
        )]
        MsSql,

        [XDoc(
            Title = "Microsoft SQL Server Analyis Services"
        )]
        MsSsas
    }
}
