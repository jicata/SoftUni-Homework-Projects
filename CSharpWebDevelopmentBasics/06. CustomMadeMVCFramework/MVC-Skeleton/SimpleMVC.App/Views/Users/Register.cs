namespace SimpleMVC.App.Views.Users
{
    using Models;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;

    public class Register : IRenderable<User>
    {
        public string Render()
        {
            string homeUrl = @"http://localhost:8081/home/index";
            string html = $@"
<a href={homeUrl}>&larr; Home</a>
<h3>Register New User</h3>
<form action=""register"" method=""POST""><br/>
Username: <input type=""text"" name=""Username""> <br/>
Password: <input type=""password"" name=""Password""> <br/>
<input type=""submit"" value=""Register"">
</form><br/>";
            return html;
        }

        public User Model { get; set; }
    }
}
