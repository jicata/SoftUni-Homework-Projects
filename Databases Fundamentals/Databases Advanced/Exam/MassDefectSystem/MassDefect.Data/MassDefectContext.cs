namespace MassDefect.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class MassDefectContext : DbContext
    {

        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

        public IDbSet<Anomaly> Anomalies { get; set; }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<SolarSystem> SolarSystems { get; set; }

        public IDbSet<Star> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany<Anomaly>(p => p.Anomalies)
                .WithMany(a => a.Victims)
                .Map(pa =>
                {
                    pa.MapLeftKey("AnomalyId");
                    pa.MapRightKey("PersonId");
                    pa.ToTable("AnomaliesVictims");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}