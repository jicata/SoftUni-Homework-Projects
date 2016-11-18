namespace _05.HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;

    public class Patient
    {
        public Patient()
        {
            this.Visitations = new HashSet<Visitation>();
            this.Diagnoses = new HashSet<Diagnose>();
            this.Medicaments = new HashSet<Medicament>();
        }


        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        public bool IsMedicallyInsured { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Medicament> Medicaments { get; set; }
        
    }
}
