using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.SpecFlow.Configuration.Process
{
    public enum ProcessType
    {
        [XDoc(
            Title = "SQL Server Integration Services",
            Description = "This type is used to execute a SQL Server Integration Services process."
        )]
        SSIS,

        [XDoc(
            Title = "Azure Data Factory",
            Description = "This type is used to execute a Azure Data Factory process."
        )]
        ADF
    }
}
