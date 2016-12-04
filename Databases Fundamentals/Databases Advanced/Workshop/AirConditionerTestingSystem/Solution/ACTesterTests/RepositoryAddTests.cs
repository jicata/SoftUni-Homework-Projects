using ACTester.Database;
using ACTester.Enumerations;
using ACTester.Exceptions;
using ACTester.Interfaces;
using ACTester.Models;
using ACTester.Utilities;


namespace ACTesterTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryAddTests
    {
        private IRepository<IAirConditioner> Repository { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Repository = new Repository<IAirConditioner>();
        }

        [TestMethod]
        public void Add_ShouldAddItemOnlyOnce()
        {
            IAirConditioner airConditioner = new StationaryAirConditioner("Toshiba", "EX100", EnergyEfficiencyRating.B, 1000);

            Assert.AreEqual(0,this.Repository.Count);

            this.Repository.Add(airConditioner);

            Assert.AreEqual(1,this.Repository.Count);
        }


        [TestMethod]
        public void Add_ShouldAddCorrectItem()
        {
            IAirConditioner airConditioner = new StationaryAirConditioner("Toshiba","EX100",EnergyEfficiencyRating.B, 1000);

            Assert.AreEqual(0, this.Repository.Count);
            
            this.Repository.Add(airConditioner);

            Assert.AreSame(airConditioner,this.Repository.GetItem(airConditioner.Manufacturer, airConditioner.Model),"Expected air conditioner did not match!");
        }

        [ExpectedException(typeof(DuplicateEntryException))]
        [TestMethod]
        public void Add_WithDuplicatedItem_ShouldThrowCorrectDuplicateEntryException()
        {
            IAirConditioner airConditioner = new StationaryAirConditioner("Toshiba", "EX100", EnergyEfficiencyRating.B, 1000);
            IAirConditioner airConditioner2 = new StationaryAirConditioner("Toshiba", "EX100", EnergyEfficiencyRating.B, 1000);

            this.Repository.Add(airConditioner);
            this.Repository.Add(airConditioner2);

            try
            {
                this.Repository.Add(airConditioner2);
            }
            catch (DuplicateEntryException ex)
            {
                Assert.AreEqual(string.Format(Constants.DuplicateEntry), ex.Message, "Expected message did not match!");
                throw new DuplicateEntryException(Constants.DuplicateEntry);
            }
        }
    }
}
