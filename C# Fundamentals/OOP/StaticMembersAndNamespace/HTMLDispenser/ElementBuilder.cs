using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispenser
{
    public class ElementBuilder
    {
        private StringBuilder elementOpener;
        private StringBuilder elementCloser;
        private StringBuilder attributeField = new StringBuilder();
        private StringBuilder contentField = new StringBuilder();


       

        public ElementBuilder(string elementName)
        {
            this.elementOpener = new StringBuilder();
            this.elementOpener.Append("<" + elementName);
            this.elementCloser = new StringBuilder();
            this.elementCloser.Append("</" + elementName + ">");
            
        }
        public StringBuilder AttributeField
        {
            get { return attributeField; }

        }
        public StringBuilder ContentField
        {
            get { return contentField; }

        }
        public StringBuilder ElementOpener
        {
            get { return elementOpener; }
            
        }
        public StringBuilder ElementCloser
        {
            get { return elementCloser; }
           
        }

        public void AddAttribute(string attribute, string value)
        {
            this.attributeField.Append(" " + attribute + "=\"" + value + "\"");
        }
        public void AddContent(string content)
        {
            contentField.Append(content);
        }

        public override string ToString()
        {
            StringBuilder finalBuild = new StringBuilder();
            finalBuild.Append(ElementOpener);
            finalBuild.Append(this.attributeField + ">");
            finalBuild.Append(this.contentField);
            finalBuild.Append(elementCloser);
            return finalBuild.ToString();
        }

        public static string operator *(ElementBuilder elemb, int multiplier)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(elemb);
            }
            return sb.ToString();
        }

        
        

        
    }
}
