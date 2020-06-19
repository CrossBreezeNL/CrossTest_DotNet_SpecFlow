using CrossBreeze.CrossDoc.CustomAttributes;
using System.Configuration;

namespace CrossBreeze.CrossTest.SpecFlow.Configuration.Test
{
    [XDoc(Description="Test configuration")]
    public class TestConfig : ConfigurationElement
    {
        // NamingConvention
        [ConfigurationProperty("namingConvention")]
        [XDoc(Description = "Naming conventions used in the tests")]
        public TestNamingConvention NamingConvention => this["namingConvention"] as TestNamingConvention;

        // TestNamingConvention
        [XDoc(Description ="Naming convention definition")]
        public class TestNamingConvention : ConfigurationElement
        {
            // TableHeader
            [ConfigurationProperty("tableHeader")]
            [XDoc(Description = "Default table header definition used in tests")]
            public TestTableHeaderNamingConvention TableHeader => this["tableHeader"] as TestTableHeaderNamingConvention;

            // TestTableHeaderNamingConvention
            [XDoc(Description = "Table header definition")]
            public class TestTableHeaderNamingConvention : ConfigurationElement
            {
                // ParameterName
                [ConfigurationProperty("parameterName", DefaultValue = "Parameter")]
                [XDoc(Description ="Parameter for which default value is specified, used only if not overwritten in specific test scenario.")]
                public string ParameterName => this["parameterName"] as string;

                // ParameterValue
                [ConfigurationProperty("parameterValue", DefaultValue = "Value")]
                [XDoc(Description = "Default value, used only if not overwritten in specific test scenario.")]
                public string ParameterValue => this["parameterValue"] as string;
            }
        }

        // ObjectTemplates
        [ConfigurationProperty("objectTemplates")]
        [ConfigurationCollection(typeof(ObjectTemplatesConfigCollection), AddItemName = "objectTemplate")]
        [XDoc(Description ="A collection of object templates that are applied on the test scenario's if applicable.")]
        public ObjectTemplatesConfigCollection ObjectTemplates => this["objectTemplates"] as ObjectTemplatesConfigCollection;

        // ObjectTemplatesConfigCollection
        [XDocAttribute(Description ="A collection of object templates")]
        public class ObjectTemplatesConfigCollection : ConfigurationElementCollection
        {
            public new ObjectTemplateConfig this[string Name] => (ObjectTemplateConfig)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new ObjectTemplateConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((ObjectTemplateConfig)element).Name;
            }
        }
    }
}
