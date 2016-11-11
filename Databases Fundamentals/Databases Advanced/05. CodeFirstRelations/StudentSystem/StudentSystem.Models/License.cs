﻿namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class License
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
