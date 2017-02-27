namespace PizzaForum.ViewModels
{
    using System.Collections.Generic;

    public class TopicDetailsViewModel
    {

        public TopicDetailsViewModel()
        {
            this.ReplyViewModels = new HashSet<ReplyViewModel>();
        }
        public bool UserLogged { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string PostedOn { get; set; }
        public ICollection<ReplyViewModel> ReplyViewModels { get; set; }
    }
}
