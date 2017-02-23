namespace MVCFramework.MVC.Extensions
{
    public static class StringExtentions
    {
        public static string ToUpperFirst(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
