namespace ACTesterTests
{
    using ACTester.Interfaces;
    using ACTester.Controller;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindAllReportsByManufacturerTests
    {

        private IAirConditionerTesterSystem Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Controller = new AirConditionerTesterSystem();
        }

        [TestMethod]
        public void FindAllReportsByManufacturer_WithoutAnyExistingReports_ShouldReturnCorrectMessage()
        {
            var result = Controller.FindAllReportsByManufacturer("Toshiba");
            var expected = "No reports.";

            Assert.AreEqual(expected, result, "Expected message did not match!");
        }

        [TestMethod]
        public void FindAllReportsByManufacturer_WithMultipleReports_ShouldReturnOnlyCorrectReports()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
            this.Controller.RegisterPlaneAirConditioner("Hitachi", "P320", 25, 750);
            this.Controller.RegisterCarAirConditioner("Toshiba", "C60", 9);
            this.Controller.TestAirConditioner("Toshiba", "EX100");
            this.Controller.TestAirConditioner("Hitachi", "P320");
            this.Controller.TestAirConditioner("Toshiba", "C60");

            var result = Controller.FindAllReportsByManufacturer("Hitachi");

            var expected =
                "Reports from Hitachi:\r\nReport\r\n====================\r\nManufacturer: Hitachi\r\nModel: P320\r\nMark: Failed\r\n====================";

            Assert.AreEqual(expected, result, "Expected message did not match!");
        }

        [TestMethod]
        public void FindAllReportsByManufacturer_WithMultipleValidReports_ShouldReturnReportsCorrectlySorted()
        {
            this.Controller.RegisterStationaryAirConditioner("Toshiba", "EX100", "B", 1000);
            this.Controller.RegisterPlaneAirConditioner("Hitachi", "P320", 25, 750);
            this.Controller.RegisterCarAirConditioner("Toshiba", "C60", 9);
            this.Controller.TestAirConditioner("Toshiba", "EX100");
            this.Controller.TestAirConditioner("Hitachi", "P320");
            this.Controller.TestAirConditioner("Toshiba", "C60");

            var result = Controller.FindAllReportsByManufacturer("Toshiba");

            var expected =
                "Reports from Toshiba:\r\nReport\r\n====================\r\nManufacturer: Toshiba\r\nModel: C60\r\nMark: Passed\r\n====================\r\nReport\r\n====================\r\nManufacturer: Toshiba\r\nModel: EX100\r\nMark: Passed\r\n====================";

            Assert.AreEqual(expected,result, "Expected message did not match!");
        }
    }
}
