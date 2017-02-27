namespace PizzaForum.ViewModels
{
    using System.Collections.Generic;

    public class TopicViewModel
    {
        
        public bool UserLoggedIn { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public int RepliesCount { get; set; }

        public string PostedOn { get; set; }


    }
}
