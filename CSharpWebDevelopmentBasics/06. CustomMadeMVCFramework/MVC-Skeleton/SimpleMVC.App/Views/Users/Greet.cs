namespace SimpleMVC.App.Views.Users
{
    using Models;
    using MVC.Interfaces.Generic;

    public class Greet : IRenderable<SessionViewModel>
    {
        public string Render()
        {
            string greet = $"<p>Hello user with session: {Model.HttpSessionId}</p>";
            return greet;
        }

        public SessionViewModel Model { get; set; }
    }
}
