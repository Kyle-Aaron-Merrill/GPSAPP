using System;

namespace DomainLayer.Models.LocationPoint
{
    internal interface ILocationPointModel
    {
        int ActivityID { get; set; }
        double Altitude { get; set; }
        double BatteryLevel { get; set; }
        double HorizontalAccuracy { get; set; }
        double Latitude { get; set; }
        int LocationID { get; set; }
        double Longitude { get; set; }
        double PopulationDensity { get; set; }
        double PowerUsage { get; set; }
        DateTime Timestamp { get; set; }
        double VerticalAccuracy { get; set; }

        void UpdatePopulationDensity();
    }
}