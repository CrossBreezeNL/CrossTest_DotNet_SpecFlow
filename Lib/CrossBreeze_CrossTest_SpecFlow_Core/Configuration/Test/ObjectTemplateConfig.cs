using CrossBreeze.CrossDoc.CustomAttributes;
using System;
using System.Configuration;

namespace CrossBreeze.CrossTest.SpecFlow.Configuration.Test
{
    [XDoc(Description ="A object template definition.")]
    public class ObjectTemplateConfig : ConfigurationElement
    {
        // Name
        [ConfigurationProperty("name", IsKey = true)]
        [XDoc(Description ="Name of the template, used to refer to it in a test scenario.")]
        public string Name => this["name"] as string;

        // ParentTemplate
        [ConfigurationProperty("parentTemplate", DefaultValue = null, IsRequired = false)]
        [XDoc(Description ="Parent template, if a template has a parent defined, everything that is specified in the parent template is (recursively) inherited unless overwritten in the child template.")]
        public String ParentTemplate => this["parentTemplate"] as String;

        // Prefix
        [ConfigurationProperty("prefix", DefaultValue = null, IsRequired = false)]
        [XDoc(Description = "Specifies the prefix that has to be prepended to the object name of the object the template is applied to.")]
        public String Prefix => this["prefix"] as String;

        // Suffix
        [ConfigurationProperty("suffix", DefaultValue = null, IsRequired = false)]
        [XDoc(Description = "Specifies the suffix that has to be apppended to the object name of the object the template is applied to.")]
        public String Suffix => this["suffix"] as String;

        // AppendPrefix
        [ConfigurationProperty("appendPrefix", DefaultValue = null, IsRequired = false)]
        [XDoc(Description = "Specifies an additional prefix if one is also inherited from the parent.")]
        public String AppendPrefix => this["appendPrefix"] as String;

        // Attributes
        [ConfigurationProperty("attributes")]
        [ConfigurationCollection(typeof(ObjectTemplateAttributeConfigCollection), AddItemName = "attribute")]
        [XDoc(Description = "A collection of default attributes.")]
        public ObjectTemplateAttributeConfigCollection Attributes => this["attributes"] as ObjectTemplateAttributeConfigCollection;

        // ObjectTemplateAttributeConfigCollection
        [XDoc(Description = "A collection of default attributes.")]
        public class ObjectTemplateAttributeConfigCollection : ConfigurationElementCollection
        {
            public new ObjectTemplateAttributeConfig this[string Name] => (ObjectTemplateAttributeConfig)BaseGet(Name);

            protected override ConfigurationElement CreateNewElement()
            {
                return new ObjectTemplateAttributeConfig();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((ObjectTemplateAttributeConfig)element).Name;
            }
        }

        // ObjectTemplateAttributeConfig
        [XDoc(Description = "A default attribute configuration.")]
        public class ObjectTemplateAttributeConfig : ConfigurationElement
        {
            // Name
            [ConfigurationProperty("name", IsKey = true)]
            [XDoc(Description = "Name of default attribute.")]
            public string Name => this["name"] as string;

            // Value
            [ConfigurationProperty("value", IsRequired = true)]
            [XDoc(Description = "Default value of attribute.")]
            public string Value => this["value"] as string;
        }
    }
}
