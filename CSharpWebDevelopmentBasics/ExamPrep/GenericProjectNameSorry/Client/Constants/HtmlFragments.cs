namespace SoftUniStore.Client.Constants
{
    using System.IO;

    public static class HtmlFragments
    {
        public static string Header = File.ReadAllText(@"../../content/header.html");
        public static string MenuNotLogged = File.ReadAllText(@"../../content/nav-not-logged.html");
        public static string MenuLogged = File.ReadAllText(@"../../content/nav-logged.html");
        public static string Footer = File.ReadAllText(@"../../content/footer.html");
    }
}
