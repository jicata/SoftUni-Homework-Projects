namespace Shouter.ViewModels
{
    using Models;

    public class ShoutViewModel
    {
        public string Content { get; set; }

        public User Author { get; set; }

        public string PostedForTime { get; set; }
    }
}
