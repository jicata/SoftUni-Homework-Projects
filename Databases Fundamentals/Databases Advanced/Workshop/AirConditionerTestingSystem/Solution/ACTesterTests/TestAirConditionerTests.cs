using ACTester.Database;

namespace ACTesterTests
{
    using ACTester.Controller;
    using ACTester.Enumerations;
    using ACTester.Exceptions;
    using ACTester.Interfaces;
    using ACTester.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class TestAirConditionerTests
    {
        [ExpectedException(typeof(NonExistantEntryException))]
        [TestMethod]
        public void TestAirConditioner_WithoutExistingEntry_ShouldThrowCorrectNonExistantEntryException()
        {
            Mock<IAirConditionerTesterDatabase> databaseMock = new Mock<IAirConditionerTesterDatabase>();
            Mock<IRepository<IAirConditioner>> fakeACrepository = new Mock<IRepository<IAirConditioner>>();

            databaseMock.Setup(x => x.AirConditioners).Returns(fakeACrepository.Object);
            fakeACrepository.Setup(x => x.GetItem(It.IsAny<string>(), It.IsAny<string>())).Throws(new NonExistantEntryException(Constants.NonExistantEntry));
            IAirConditionerTesterDatabase fakeDatabase = databaseMock.Object;
            var controller = new AirConditionerTesterSystem(fakeDatabase);

            try
            {
                controller.TestAirConditioner("Toshiba", "EX100");
            }
            catch (NonExistantEntryException ex)
            {
                Assert.AreEqual(Constants.NonExistantEntry, ex.Message, "Expected message did not match!");
                throw new NonExistantEntryException("");
            }
        }

        [TestMethod]
        public void TestAirConditioner_WithCorrectInput_ShouldCallAirConditionersGetItemMethod()
        {
            Mock<IAirConditioner> fakeAC = new Mock<IAirConditioner>();
            Mock<IAirConditionerTesterDatabase> databaseMock = new Mock<IAirConditionerTesterDatabase>();
            Mock<IRepository<IAirConditioner>> fakeACrepository = new Mock<IRepository<IAirConditioner>>();
            Mock<IReportsRepository> fakeReportsRepository = new Mock<IReportsRepository>();

            databaseMock.Setup(x => x.AirConditioners).Returns(fakeACrepository.Object);
            databaseMock.Setup(x => x.Reports).Returns(fakeReportsRepository.Object);
            fakeACrepository.Setup(x => x.GetItem(It.IsAny<string>(), It.IsAny<string>())).Returns(fakeAC.Object);

            IAirConditionerTesterDatabase fakeDatabase = databaseMock.Object;
            var controller = new AirConditionerTesterSystem(fakeDatabase);

            controller.TestAirConditioner("Toshiba", "EX100");
            fakeACrepository.Verify(x=>x.GetItem(It.IsAny<string>(),It.IsAny<string>()),Times.Exactly(1));
        }


        [TestMethod]
        public void TestAirConditioner_WithCorrectInput_ShouldCallAirConditionerTestMethod()
        {
            Mock<IAirConditioner> fakeAC = new Mock<IAirConditioner>();
            Mock<IAirConditionerTesterDatabase> databaseMock = new Mock<IAirConditionerTesterDatabase>();
            Mock<IRepository<IAirConditioner>> fakeACrepository = new Mock<IRepository<IAirConditioner>>();
            Mock<IReportsRepository> fakeReportsRepository = new Mock<IReportsRepository>();

            databaseMock.Setup(x => x.AirConditioners).Returns(fakeACrepository.Object);
            databaseMock.Setup(x => x.Reports).Returns(fakeReportsRepository.Object);
            fakeACrepository.Setup(x => x.GetItem(It.IsAny<string>(), It.IsAny<string>())).Returns(fakeAC.Object);

            IAirConditionerTesterDatabase fakeDatabase = databaseMock.Object;
            var controller = new AirConditionerTesterSystem(fakeDatabase);

            controller.TestAirConditioner("Toshiba", "EX100");
            fakeAC.Verify(x => x.Test(), Times.Exactly(1));
        }

        [TestMethod]
        public void TestAirConditioner_WithCorrectInput_ShouldCallReportsAddMethod()
        {
            Mock<IAirConditioner> fakeAC = new Mock<IAirConditioner>();
            Mock<IAirConditionerTesterDatabase> databaseMock = new Mock<IAirConditionerTesterDatabase>();
            Mock<IRepository<IAirConditioner>> fakeACrepository = new Mock<IRepository<IAirConditioner>>();
            Mock<IReportsRepository> fakeReportsRepository = new Mock<IReportsRepository>();

            databaseMock.Setup(x => x.AirConditioners).Returns(fakeACrepository.Object);
            databaseMock.Setup(x => x.Reports).Returns(fakeReportsRepository.Object);
            fakeACrepository.Setup(x => x.GetItem(It.IsAny<string>(), It.IsAny<string>())).Returns(fakeAC.Object);

            IAirConditionerTesterDatabase fakeDatabase = databaseMock.Object;
            var controller = new AirConditionerTesterSystem(fakeDatabase);

            controller.TestAirConditioner("Toshiba", "EX200");

            fakeReportsRepository.Verify(x => x.Add(It.IsAny<IReport>()), Times.Exactly(1));

        }

        [TestMethod]
        public void TestAirConditioner_WithCorrectInput_ShouldAddCorrectReport()
        {
            Mock<IAirConditioner> fakeAC = new Mock<IAirConditioner>();
            fakeAC.Setup(x => x.Manufacturer).Returns("Toshiba");
            fakeAC.Setup(x => x.Model).Returns("EX200");
            fakeAC.Setup(x => x.Test()).Returns(false);
            Mock<IAirConditionerTesterDatabase> databaseMock = new Mock<IAirConditionerTesterDatabase>();
            Mock<IRepository<IAirConditioner>> fakeACrepository = new Mock<IRepository<IAirConditioner>>();
            Mock<IReportsRepository> fakeReportsRepository = new Mock<IReportsRepository>();

            databaseMock.Setup(x => x.AirConditioners).Returns(fakeACrepository.Object);
            databaseMock.Setup(x => x.Reports).Returns(fakeReportsRepository.Object);
            fakeACrepository.Setup(x => x.GetItem(It.IsAny<string>(), It.IsAny<string>())).Returns(fakeAC.Object);

            IReport report = null;
            fakeReportsRepository.Setup(x => x.Add(It.IsAny<IReport>())).Callback<IReport>(r => report = r);
            IAirConditionerTesterDatabase fakeDatabase = databaseMock.Object;
            var controller = new AirConditionerTesterSystem(fakeDatabase);

            controller.TestAirConditioner("Toshiba", "EX200");

            Assert.AreEqual("Toshiba", report.Manufacturer, "Manufacturer did not match!");
            Assert.AreEqual("EX200", report.Model, "Model did not match!");
            Assert.AreEqual(Mark.Failed, report.Mark, "Mark did not match!");

        }

        [TestMethod]
        public void TestAirConditioner_WithCorrectInput_ShouldReturnSuccessMessage()
        {
            Mock<IAirConditioner> fakeAC = new Mock<IAirConditioner>();
            fakeAC.Setup(x => x.Manufacturer).Returns("Toshiba");
            fakeAC.Setup(x => x.Model).Returns("EX200");
            fakeAC.Setup(x => x.Test()).Returns(false);
            Mock<IAirConditionerTesterDatabase> databaseMock = new Mock<IAirConditionerTesterDatabase>();
            Mock<IRepository<IAirConditioner>> fakeACrepository = new Mock<IRepository<IAirConditioner>>();
            Mock<ReportsRepository> fakeReportsRepository = new Mock<ReportsRepository>();

            databaseMock.Setup(x => x.AirConditioners).Returns(fakeACrepository.Object);
            databaseMock.Setup(x => x.Reports).Returns(fakeReportsRepository.Object);
            fakeACrepository.Setup(x => x.GetItem(It.IsAny<string>(), It.IsAny<string>())).Returns(fakeAC.Object);

            IAirConditionerTesterDatabase fakeDatabase = databaseMock.Object;
            var controller = new AirConditionerTesterSystem(fakeDatabase);

            var result = controller.TestAirConditioner("Toshiba", "EX200");
            Assert.AreEqual("Air Conditioner model EX200 from Toshiba tested successfully.", result, "Expected messages did not match!");

        }

        [ExpectedException(typeof(DuplicateEntryException))]
        [TestMethod]
        public void TestAirConditioner_WithoutAlreadyExistingReport_ShouldThrowCorrectDuplicateEntryException()
        {
            Mock<IAirConditioner> fakeAC = new Mock<IAirConditioner>();
            fakeAC.Setup(x => x.Test()).Returns(true);
            Mock<IAirConditionerTesterDatabase> databaseMock = new Mock<IAirConditionerTesterDatabase>();
            Mock<IRepository<IAirConditioner>> fakeACrepository = new Mock<IRepository<IAirConditioner>>();
            Mock<IReportsRepository> fakeReportsRepository = new Mock<IReportsRepository>();

            databaseMock.Setup(x => x.AirConditioners).Returns(fakeACrepository.Object);
            databaseMock.Setup(x => x.Reports).Returns(fakeReportsRepository.Object);
            fakeACrepository.Setup(x => x.GetItem(It.IsAny<string>(), It.IsAny<string>())).Returns(fakeAC.Object);
            fakeReportsRepository.Setup(x => x.Add(It.IsAny<IReport>()))
                .Throws(new DuplicateEntryException(Constants.DuplicateEntry));

            IAirConditionerTesterDatabase fakeDatabase = databaseMock.Object;
            var controller = new AirConditionerTesterSystem(fakeDatabase);

            controller.TestAirConditioner("Toshiba", "EX100");

            try
            {
                controller.TestAirConditioner("Toshiba", "EX100");
            }
            catch (DuplicateEntryException ex)
            {
                Assert.AreEqual(string.Format(Constants.DuplicateEntry), ex.Message, "Expected message did not match!");
                throw new DuplicateEntryException(Constants.DuplicateEntry);
            }
        }
    }
}
