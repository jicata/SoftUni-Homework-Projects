namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    public class Login : IRenderable
    {
        public string Render()
        {
            string homeUrl = @"http://localhost:8081/home/index";
            string html = $@"
            <a href={homeUrl}>&larr; Home</a>
            <h3>Login</h3>
            <form action=""login"" method=""POST""><br/>
            Username: <input type=""text"" name=""Username""> <br/>
            Password: <input type=""password"" name=""Password""> <br/>
            <input type=""submit"" value=""Log in"">
            </form><br/>";
            return html;
        }
    }
}
