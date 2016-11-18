namespace _05.HospitalDatabase.Data
{
    using System.Data.Entity;
    using Models;

    public class HospitalContext : DbContext
    {

        public HospitalContext()
            : base("name=HospitalContext")
        {
        }

        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Diagnose> Diagnoses { get; set; }
        public IDbSet<Medicament> Medicaments { get; set; }
        public IDbSet<Visitation> Visitations { get; set; }
        public IDbSet<Doctor> Doctors { get; set; }
    }
}
