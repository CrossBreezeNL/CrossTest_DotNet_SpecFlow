using CrossBreeze.CrossDoc.CustomAttributes;

namespace CrossBreeze.CrossTest.Process.Adf.Configuration
{
    public enum AdfProcessType
    {
        [XDoc(
            Title = "Azure Data Factory Pipeline",
            Description = "This type is used to execute a pipeline stored on azure data factory."
        )]
        AdfPipeline
        
    }
}
