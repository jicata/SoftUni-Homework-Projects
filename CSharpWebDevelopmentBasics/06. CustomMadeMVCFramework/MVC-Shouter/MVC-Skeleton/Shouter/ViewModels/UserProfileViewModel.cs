namespace Shouter.ViewModels
{
    using System.Collections.Generic;

    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
            this.Shouts = new List<ShoutViewModel>();
        }
        public string Username { get; set; }

        public string FollowStatus { get; set; }

        public string FollowOption { get; set; }

        public List<ShoutViewModel> Shouts { get; set; }

    }
}
