namespace _05.HospitalDatabase.Models.CustomAttributes
{
    using System.ComponentModel.DataAnnotations;

    public class PasswordAttribute : ValidationAttribute
    {
        public PasswordAttribute(int minLength, int maxLength)
        {
            this.MinLength = minLength;
            this.MaxLength = maxLength;
        }

       
      

        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public bool ContainsLowerCase { get; set; }

        public bool ContainsUpperCase { get; set; }

        public bool ContainsDigit { get; set; }

        public bool ContainsSpecialSymbol { get; set; }


        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            string password = value.ToString();
            if (password.Length < MinLength || password.Length > MaxLength)
            {
                return false;
            }
            return true;
        }
    }
}
