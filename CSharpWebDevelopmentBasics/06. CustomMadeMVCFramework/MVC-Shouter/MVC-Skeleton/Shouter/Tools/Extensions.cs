namespace Shouter.Tools
{
    using System;

    public static class Extensions
    {
        public static string CalculateTimeSincePost(DateTime? shoutPostedOn)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSincePost = now - shoutPostedOn.Value;
            if (timeSincePost.Seconds < 5)
            {
                return "less than a second";
            }
            else if (timeSincePost.Minutes < 1)
            {
                return "less than a minute";
            }
            else if (timeSincePost.Hours < 1)
            {
                return $"{timeSincePost.Minutes} minutes ago";
            }
            else if (timeSincePost.Days < 1)
            {
                return $"{timeSincePost.Hours} hours ago";
            }
            else if (timeSincePost.Days < 30)
            {
                return $"{timeSincePost.Days} days ago";
            }
            else if (timeSincePost.Days < 365)
            {
                return $"{timeSincePost.Days / 30} months ago";
            }
            else
            {
                return "more than an year ago";
            }
        }
    }
}
