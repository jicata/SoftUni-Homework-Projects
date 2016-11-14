namespace VehicleSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Models.Motor;

    public class VehicleSystemContext : DbContext
    {
        public VehicleSystemContext()
            : base("name=VehicleSystemContext")
        {
        }
        public IDbSet<Carriage> Carriages { get; set; }
        public IDbSet<Locomotive> Locomotives { get; set; }
        public IDbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>().HasOptional(t=>t.Locomotive).WithRequired(l=>l.Train);
            base.OnModelCreating(modelBuilder);
        }
    }
}