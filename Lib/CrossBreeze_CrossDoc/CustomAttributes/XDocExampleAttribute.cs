using System;

namespace CrossBreeze.CrossDoc.CustomAttributes
{
    /// <summary>
    /// Custom attribute class to annotate a code blocks with an example.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class XDocExampleAttribute : Attribute
    {
        private string title;
        private string description;
        private string example;

        public XDocExampleAttribute() { }

        public XDocExampleAttribute(string example)
        {
            this.example = example;
        }

        public XDocExampleAttribute(string title, string example)
        {
            this.title = title;
            this.example = example;
        }

        public XDocExampleAttribute(string title, string description, string example)
        {
            this.title = title;
            this.description = description;
            this.example = example;
        }

        public virtual string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public virtual string Example
        {
            get
            {
                return this.example;
            }
            set {
                this.example = value;
            }
        }
    }
}
