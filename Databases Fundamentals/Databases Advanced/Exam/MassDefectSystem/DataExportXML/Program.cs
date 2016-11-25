namespace DataExportXML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using MassDefect.Data;

    class Program
    {
        static void Main()
        {
            MassDefectContext context = new MassDefectContext();
            int count = context.Anomalies.Find(12).Victims.Count;
            var anomaliesToExport = context.Anomalies
                .OrderBy(a => a.Id)
                .Select(
                    a =>
                        new
                        {
                            Id = a.Id,
                            OriginPlanetName = a.OriginPlanet.Name,
                            TeleportPlanetName = a.TeleportPlanet.Name,
                            Victims = a.Victims.Select(v => v.Name)
                        }).ToList();
            XDocument anomaliesXml = new XDocument(new XElement("anomalies"));
            foreach (var anomaly in anomaliesToExport)
            {
                XElement anomalyElement = new XElement("anomaly");
                anomalyElement.Add(new XAttribute("id", anomaly.Id));
                anomalyElement.Add(new XAttribute("origin-planet", anomaly.OriginPlanetName));
                anomalyElement.Add(new XAttribute("teleport-planet", anomaly.TeleportPlanetName));

                XElement victimsElement = new XElement("victims");
                foreach (var victim in anomaly.Victims)
                {
                    XElement victimElement = new XElement("victim");
                    victimElement.Add(new XAttribute("name", victim));
                    victimsElement.Add(victimElement);
                }
                anomalyElement.Add(victimsElement);

                anomaliesXml.Root.Add(anomalyElement);
            }
            anomaliesXml.Save("../../anomalies.xml");
        }
    }
}
