namespace Phonebook.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class ContactDTO
    {
        public ContactDTO()
        {
            this.Phones = new List<string>();
            this.Emails = new List<string>();
        }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Site { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<string> Phones { get; set; }

        public virtual ICollection<string> Emails { get; set; }
    }
}
