using PhotoShare.Models.Validation;
using System.Collections.Generic;

namespace PhotoShare.Models
{
    public class Tag
    {
        private ICollection<Album> albums;

        public Tag()
        {
            this.albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
