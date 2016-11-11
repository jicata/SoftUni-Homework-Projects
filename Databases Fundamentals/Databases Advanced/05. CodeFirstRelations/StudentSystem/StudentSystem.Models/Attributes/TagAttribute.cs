namespace StudentSystem.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Helpers;

    public class TagAttribute:ValidationAttribute
    {
        // don't take this attribute seriously
        public override bool IsValid(object value)
        {
            bool isValid = true;
            string tag = value.ToString();
            if (tag.Any(Char.IsWhiteSpace) || tag.Length > 20 || !tag.StartsWith("#"))
            {
                tag = TagTransformer.Transformer(tag);
            }
            
            return true;
        }
    }
}
