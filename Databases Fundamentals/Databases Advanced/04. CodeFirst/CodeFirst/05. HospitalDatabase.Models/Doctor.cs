namespace _05.HospitalDatabase.Models
{
    using System.Collections.Generic;

    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Specialty { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
      
    }
}


