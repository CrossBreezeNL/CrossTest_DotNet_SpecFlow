using System;

namespace CrossBreeze.CrossDoc.CustomAttributes
{
    /// <summary>
    /// Custom attribute class to annotate a code blocks with a title and description.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited=false)]    
    public class XDocAttribute : Attribute
    {
        private string title;
        private string description;

        public XDocAttribute()
        {
        }

        public XDocAttribute(string description)
        {
            this.description = description;
        }

        public XDocAttribute(string title, string description)
        {
            this.title = title;
            this.description = description;
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
        
    }
}
