using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispenser
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string imageSource, string alt, string title)
        {
            ElementBuilder element = new ElementBuilder("img");
            element.AddAttribute("src",imageSource);
            element.AddAttribute("alt",alt);
            element.AddAttribute("title", title);
            StringBuilder sb = new StringBuilder();
            sb.Append(element.ElementOpener);
            sb.Append(element.AttributeField + ">");
            return sb.ToString();
        }
        
        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder element = new ElementBuilder("a");
            element.AddAttribute("url", url);
            element.AddAttribute("title", title);
            element.AddContent(text);
            StringBuilder sb = new StringBuilder();
            sb.Append(element.ElementOpener);
            sb.Append(element.AttributeField+">");
            sb.Append(element.ContentField);
            sb.Append(element.ElementCloser);
            return sb.ToString();
        }
        
        public static string CreateInput(string inputType, string name, string value)
        {
            ElementBuilder element = new ElementBuilder("input");
            element.AddAttribute("input Type", inputType);
            element.AddAttribute("name", name);
            element.AddAttribute("value", value);
            StringBuilder sb = new StringBuilder();
            sb.Append(element.ElementOpener);
            sb.Append(element.AttributeField + ">");
            return sb.ToString();
        }
    }
}
