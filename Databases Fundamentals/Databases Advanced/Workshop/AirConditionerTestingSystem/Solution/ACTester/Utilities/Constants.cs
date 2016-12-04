namespace ACTester.Utilities
{
    public static class Constants
    {
        public const string IncorrectPropertyLength = "{0}'s name must be at least {1} symbols long.";

        public const string NoReports = "No reports.";

        public const string InvalidCommand = "Invalid command";

        public const string Status = "Jobs complete: {0:F2}%";

        public const string IncorrectEnergyEfficiencyRating = "Energy efficiency rating must be between \"A\" and \"E\".";

        public const string NonPositiveNumber = "{0} must be a positive integer.";

        public const string DuplicateEntry = "An entry for the given model already exists.";

        public const string NonExistantEntry = "The specified entry does not exist.";

        public const string RegisterAirConditioner = "Air Conditioner model {0} from {1} registered successfully.";

        public const string TestAirConditioner = "Air Conditioner model {0} from {1} tested successfully.";

        public const int ModelMinLength = 2;

        public const int ManufacturerMinLength = 4;

        public const int MinCarVolume = 3;

        public const int MinPlaneElectricity = 150;

        public const int RegisterStationaryAcParametersCount = 4;

        public const int RegisterCarAcParametersCount = 3;

        public const int RegisterPlaneAcParametersCount = 4;

        public const int TestAcParametersCount = 2;

        public const int FindAcParametersCount = 2;

        public const int FindReportParametersCount = 2;

        public const int FindReportsByManufacturerParametersCount = 1;

        public const int StatusParametersCount = 0;
    }
}
