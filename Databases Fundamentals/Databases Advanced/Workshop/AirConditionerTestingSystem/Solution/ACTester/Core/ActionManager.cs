namespace ACTester.Core
{
    using System;
    using ACTester.Controller;
    using ACTester.Interfaces;
    using ACTester.Utilities;

    public class ActionManager : IActionManager
    {
        public ActionManager(IAirConditionerTesterSystem controller)
        {
            this.Controller = controller;
        }

        public ActionManager() : this(new AirConditionerTesterSystem())
        {
        }

        private IAirConditionerTesterSystem Controller { get; set; }

        public string ExecuteCommand(ICommand command)
        {
            try
            {
                switch (command.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.ValidateParametersCount(command, Constants.RegisterStationaryAcParametersCount);
                        return this.Controller.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            command.Parameters[2],
                            int.Parse(command.Parameters[3]));
                    case "RegisterCarAirConditioner":
                        this.ValidateParametersCount(command, Constants.RegisterCarAcParametersCount);
                        return this.Controller.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]));
                    case "RegisterPlaneAirConditioner":
                        this.ValidateParametersCount(command, Constants.RegisterPlaneAcParametersCount);
                        return this.Controller.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            int.Parse(command.Parameters[3]));
                    case "TestAirConditioner":
                        this.ValidateParametersCount(command, Constants.TestAcParametersCount);
                        return this.Controller.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindAirConditioner":
                        this.ValidateParametersCount(command, Constants.FindAcParametersCount);
                        return this.Controller.FindAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindReport":
                        this.ValidateParametersCount(command, Constants.FindReportParametersCount);
                        return this.Controller.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]);
                    case "FindAllReportsByManufacturer":
                        this.ValidateParametersCount(command, Constants.FindReportsByManufacturerParametersCount);
                        return this.Controller.FindAllReportsByManufacturer(
                            command.Parameters[0]);
                    case "Status":
                        this.ValidateParametersCount(command, Constants.StatusParametersCount);
                        return this.Controller.Status();
                    default:
                        throw new InvalidOperationException(Constants.InvalidCommand);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex.InnerException);
            }
        }

        private void ValidateParametersCount(ICommand command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }
        }
    }
}
