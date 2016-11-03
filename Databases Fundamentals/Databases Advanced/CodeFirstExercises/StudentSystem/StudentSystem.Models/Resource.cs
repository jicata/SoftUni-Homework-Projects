namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TypeOfResource ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public ICollection<License> License { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.ResourceType} {this.Url}";
        }
    }
}
