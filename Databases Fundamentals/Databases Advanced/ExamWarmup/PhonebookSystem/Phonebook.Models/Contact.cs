namespace Phonebook.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Contact
    {
        public Contact()
        {
            this.Phones = new HashSet<Phone>();
            this.Emails = new HashSet<Email>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Site { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
        
        public virtual ICollection<Email> Emails { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Position: {this.Position?? "(None)"}");
            sb.AppendLine($"Company: {this.Company ?? "(None)"}");
            sb.AppendLine($"Site: {this.Site ?? "(None)"}");
            sb.AppendLine($"Notes: {this.Notes ?? "(None)"}");
            sb.AppendLine($"Phones: ");
            if (!this.Phones.Any())
            {
                sb.AppendLine("(None)");
            }
            else
            {
                foreach (var phone in Phones)
                {
                    sb.AppendLine($"--{phone}");
                }
            }
            sb.AppendLine($"Emails: ");
            if (!this.Emails.Any())
            {
                sb.AppendLine("(None)");
            }
            else
            {
                foreach (var email in Emails)
                {
                    sb.AppendLine($"--{email}");
                }
            }
            return sb.ToString();
        }
    }
}
