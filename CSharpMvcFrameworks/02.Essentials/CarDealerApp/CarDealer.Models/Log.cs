namespace CarDealer.Models
{
    using System;

    public class Log
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public DateTime? Time { get; set; }
    }
}
