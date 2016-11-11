namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class StudentAlbums
    {

        [Key, Column(Order = 0)]
        public int StudentID { get; set; }
        [Key, Column(Order = 1)]
        public int AlbumID { get; set; }

        public virtual StudentRole StudentRole { get; set; }

        public virtual Student Student { get; set; }

        public virtual Album Album { get; set; }


    }
}
