namespace PhotoShare.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string pattern = @"(?<=\s|^)[a-z0-9A-Z]+[-._]*[a-z0-9A-Z]+@[a-z0-9A-Z]+([-][a-z0-9A-Z]+)*(\.[a-z0-9A-Z]+([-][a-z0-9A-Z]+)*)+";
            Regex regex = new Regex(pattern);
            if(!regex.IsMatch(value.ToString()))
            {
                return false;
            } 
            return true;
        }
        
    }
}
