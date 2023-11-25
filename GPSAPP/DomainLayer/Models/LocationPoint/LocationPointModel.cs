using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.LocationPoint
{
    public class LocationPointModel : ILocationPointModel
    {
        public int LocationID { get; set; }

        // Reference to the associated activity
        [Required(ErrorMessage = "ActivityID is required.")]
        public int ActivityID { get; set; }

        // Geographic coordinates
        [Required(ErrorMessage = "Latitude is required.")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Altitude is required.")]
        public double Altitude { get; set; }

        // Timestamp of the location point
        [Required(ErrorMessage = "Timestamp is required.")]
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        // Power consumption information
        [Range(0, 100, ErrorMessage = "BatteryLevel must be between 0 and 100.")]
        public double BatteryLevel { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "PowerUsage must be a non-negative value.")]
        public double PowerUsage { get; set; }

        // Location accuracy
        [Range(0, double.MaxValue, ErrorMessage = "HorizontalAccuracy must be a non-negative value.")]
        public double HorizontalAccuracy { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "VerticalAccuracy must be a non-negative value.")]
        public double VerticalAccuracy { get; set; }

        // Population density-related properties
        [Range(0, double.MaxValue, ErrorMessage = "PopulationDensity must be a non-negative value.")]
        public double PopulationDensity { get; set; }

        // Other properties for future considerations
        // public double Speed { get; set; }
        // public double Heading { get; set; }
        // ...

        // Method to calculate or update PopulationDensity based on your logic
        public void UpdatePopulationDensity()
        {
            // Your logic to calculate or update population density
        }
    }
}