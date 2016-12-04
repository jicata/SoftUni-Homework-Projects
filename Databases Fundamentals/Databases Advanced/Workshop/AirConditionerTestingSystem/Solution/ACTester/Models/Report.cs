namespace ACTester.Models
{
    using System.Text;
    using ACTester.Enumerations;
    using ACTester.Interfaces;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, Mark mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; }

        public string Model { get; }

        public Mark Mark { get; private set; }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine("Report");
            print.AppendLine("====================");
            print.AppendLine(string.Format("Manufacturer: {0}", this.Manufacturer));
            print.AppendLine(string.Format("Model: {0}", this.Model));
            print.AppendLine(string.Format("Mark: {0}", this.Mark));
            print.Append("====================");
            return print.ToString();
        }
    }
}
