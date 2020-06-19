using CrossBreeze.CrossDoc.CustomAttributes;
using System;
using System.IO;

namespace CrossTestDocumenter
{
    public static class DocumentationHelper
    {
        public static string GetXDocTitleAndDescription(XDocAttribute xDocAttribute)
        {
            string xDocString = "";

            if (xDocAttribute != null)
            {
                // Add the title attribute if it is set.
                if (xDocAttribute.Title != null && xDocAttribute.Title.Length > 0)
                    xDocString += string.Format(" title=\"{0}\"", EntityEncode(xDocAttribute.Title));

                // Add the description attribute if it is set.
                if (xDocAttribute.Description != null && xDocAttribute.Description.Length > 0)
                    xDocString += string.Format(" description=\"{0}\"", EntityEncode(xDocAttribute.Description));
            }

            // Return the XDoc part of an element.
            return xDocString;
        }

        public static void WriteToOutput(String content, int indent, StreamWriter sw)
        {
            content = content.PadLeft(content.Length + indent * 2);
            Console.WriteLine(content);
            sw.WriteLine(content);
        }

        public static string EntityEncode(String text)
        {
            return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;").Replace("\"", "&quot;");
        }
    }
}
