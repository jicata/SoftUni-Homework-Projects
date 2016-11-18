namespace _05.HospitalDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<_05.HospitalDatabase.Data.HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalContext context)
        {
            Visitation visition = new Visitation()
            {
                Date = DateTime.Today,
                Comments = "Lupus definetly"
            };
            Doctor doc = new Doctor() {FirstName = "Kris", LastName = "Milkin", Specialty = "Stomatology"};

            Medicament  medicament= new Medicament()
            {
                Name = "Autoimmuneixoid",               
            };

            Diagnose diagnose = new Diagnose() {Comments = "He's definitely got it", Name = "Lupus"};

            Patient patientZero = new Patient()
            {
                FirstName = "Cherniq",
                LastName = "Negur",
                Address = "Sofia, Lulin",
                DateOfBirth = new DateTime?(new DateTime(1991, 02, 04)),
                IsMedicallyInsured = true
            };

            doc.Visitations.Add(visition);
            patientZero.Medicaments.Add(medicament);
            patientZero.Visitations.Add(visition);
            patientZero.Diagnoses.Add(diagnose);

            context.Doctors.Add(doc);
            context.Patients.Add(patientZero);
            context.SaveChanges();
        }
    }
}
