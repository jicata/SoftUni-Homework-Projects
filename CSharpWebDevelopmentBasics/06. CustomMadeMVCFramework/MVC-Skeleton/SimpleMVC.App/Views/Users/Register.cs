namespace SimpleMVC.App.Views.Users
{
    using MVC.Interfaces;
    public class Register:IRenderable
    {
        public string Render()
        {
            string html = @"<h3>Register New User</h3>
<form action=""register"" method=""POST""><br/>
Username: <input type=""text"" name=""Username""> <br/>
Password: <input type=""password"" name=""Password""> <br/>
<input type=""submit"" value=""Register"">
</form><br/>";
            return html;
        }
    }
}
