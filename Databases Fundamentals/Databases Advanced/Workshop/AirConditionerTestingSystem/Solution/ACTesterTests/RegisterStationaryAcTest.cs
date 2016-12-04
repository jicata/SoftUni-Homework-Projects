namespace ACTesterTests
{
    using System;
    using ACTester.Controller;
    using ACTester.Core;
    using ACTester.Exceptions;
    using ACTester.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterStationaryAcTest
    {
        private IAirConditionerTesterSystem Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Controller = new AirConditionerTesterSystem();
        }

        [TestMethod]
        public void RegisterStationaryAc_WithCorrectInput_ShouldReturnSuccesMessage()
        {
            var result = Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
            Assert.AreEqual("Air Conditioner model EX100 from Toshiba registered successfully.", result, "Expected message did not match!");
        }

        [ExpectedException(typeof(DuplicateEntryException))]
        [TestMethod]
        public void RegisterStationaryAc_WithDuplicateAc_ShouldThrowDuplicateException()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
        }

        [TestMethod]
        public void RegisterStationaryAc_WithDuplicateAc_ShouldThrowCorrectExceptionMessage()
        {
            try
            {
                this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
                this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
            }
            catch (DuplicateEntryException ex)
            {
                Assert.AreEqual("An entry for the given model already exists.", ex.Message,"Expected message did not match!");
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RegisterStationaryAc_WithIncorrectEnergyEfficiencyRating_ShouldThrowArgumentException()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "F", 1000);
        }

        [TestMethod]
        public void RegisterStationaryAc_WithIncorrectEnergyEfficiencyRating_ShouldThrowCorrectExceptionMessage()
        {
            try
            {
                this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "F", 1000);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(@"Energy efficiency rating must be between ""A"" and ""E"".", ex.Message, "Expected message did not match!");
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RegisterStationaryAc_WithIncorrectManufacturerName_ShouldThrowArgumentException()
        {
            this.Controller.RegisterStationaryAirConditioner("To", "EX100", "B", 1000);
        }

        [TestMethod]
        public void RegisterStationaryAc_WithIncorrectManufacturerName_ShouldThrowCorrectExceptionMessage()
        {
            try
            {
                this.Controller.RegisterStationaryAirConditioner("To", "EX100", "B", 1000);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Manufacturer's name must be at least 4 symbols long.", ex.Message, "Expected message did not match!");
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RegisterStationaryAc_WithIncorrectModelName_ShouldThrowArgumentException()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "E", "B", 1000);
        }

        [TestMethod]
        public void RegisterStationaryAc_WithIncorrectModelName_ShouldThrowCorrectExceptionMessage()
        {
            try
            {
                this.Controller.RegisterStationaryAirConditioner("Toshiba", "E", "B", 1000);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Model's name must be at least 2 symbols long.", ex.Message, "Expected message did not match!");
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RegisterStationaryAc_WithZeroPowerUsage_ShouldThrowArgumentException()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 0);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RegisterStationaryAc_WithNegativePowerUsage_ShouldThrowArgumentException()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", -50);
        }

        [TestMethod]
        public void RegisterStationaryAc_WithIncorrectPowerUsage_ShouldThrowCorrectExceptionMessage()
        {
            try
            {
                this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", -50);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Power Usage must be a positive integer.", ex.Message, "Expected message did not match!");
            }
        }
    }
}
