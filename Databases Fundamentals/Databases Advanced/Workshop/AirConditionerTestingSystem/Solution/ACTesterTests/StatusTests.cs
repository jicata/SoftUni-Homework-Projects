namespace ACTesterTests
{
    using ACTester.Controller;
    using ACTester.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StatusTests
    {
        private IAirConditionerTesterSystem Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Controller = new AirConditionerTesterSystem();
        }

        [TestMethod]
        public void Status_ShouldReturnCorrectlyFormattedResult()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
            this.Controller.RegisterCarAirConditioner("Toshiba", "C60", 9);
            this.Controller.RegisterPlaneAirConditioner("Hitachi", "P320", 25, 750);
            this.Controller.TestAirConditioner("Hitachi", "P320");
            var result = Controller.Status();
            Assert.AreEqual("Jobs complete: 33.33%",result,"Expected messages did not match!");
        }

        [TestMethod]
        public void Status_ShouldReturnCorrectlyRoundedResult()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
            this.Controller.RegisterCarAirConditioner("Toshiba", "C60", 9);
            this.Controller.RegisterPlaneAirConditioner("Hitachi", "P320", 25, 750);
            this.Controller.TestAirConditioner("Hitachi", "P320");
            this.Controller.TestAirConditioner("Toshiba", "C60");
            var result = Controller.Status();
            Assert.AreEqual("Jobs complete: 66.67%", result, "Expected messages did not match!");
        }

        [TestMethod]
        public void Status_WithoutAnyAirConditioners_ShouldReturnZeroPercent()
        {
            var result = Controller.Status();
            Assert.AreEqual("Jobs complete: 0.00%", result, "Expected messages did not match!");
        }

        [TestMethod]
        public void Status_WithExistingNonTestedAirConditioners_ShouldReturnZeroPercent()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
            this.Controller.RegisterCarAirConditioner("Toshiba", "C60", 9);
            this.Controller.RegisterPlaneAirConditioner("Hitachi", "P320", 25, 750);
            var result = Controller.Status();
            Assert.AreEqual("Jobs complete: 0.00%", result, "Expected messages did not match!");
        }
    }
}
