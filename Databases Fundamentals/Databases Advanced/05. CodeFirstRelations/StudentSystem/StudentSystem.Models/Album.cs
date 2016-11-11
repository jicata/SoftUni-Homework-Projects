namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public Album()
        {
            this.Students = new HashSet<StudentAlbums>();
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int[] BackgroundColour { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        public virtual ICollection<StudentAlbums> Students { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        
        
    }
}
