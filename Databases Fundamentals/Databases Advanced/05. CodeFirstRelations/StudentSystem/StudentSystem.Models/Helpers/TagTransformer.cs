namespace StudentSystem.Models.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TagTransformer
    {
        public static string Transformer(string tag)
        {

            if (tag.Any(Char.IsWhiteSpace))
            {
                List<char> chars = tag.ToList();
                chars.RemoveAll(Char.IsWhiteSpace);
                tag = chars.ToString();
            }
            if (!tag.StartsWith("#"))
            {
                tag = "#" + tag;
            }
            if (tag.Length > 20)
            {
                tag = tag.Substring(0, 20);
            }
            return tag;

        }
    }
}
