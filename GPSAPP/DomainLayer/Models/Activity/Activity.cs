using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Activity
{
    internal class ActivityModel : IActivityModel
    {
        public int ActivityID { get; set; }

        // User-related information
        [Required(ErrorMessage = "UserID is required.")]
        public int UserID { get; set; }

        // Activity details
        [Required(ErrorMessage = "ActivityType is required.")]
        [StringLength(50, ErrorMessage = "ActivityType must be at most 50 characters.")]
        public string ActivityType { get; set; }

        [Required(ErrorMessage = "StartTime is required.")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required.")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Distance is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Distance must be a non-negative value.")]
        public double Distance { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        public TimeSpan Duration { get; set; }

        [Required(ErrorMessage = "AverageSpeed is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "AverageSpeed must be a non-negative value.")]
        public double AverageSpeed { get; set; }

        [Required(ErrorMessage = "ElevationGain is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "ElevationGain must be a non-negative value.")]
        public double ElevationGain { get; set; }

        // Other properties for future considerations
        // [StringLength] or other annotations as needed
        // public string Title { get; set; }
        // public string Description { get; set; }
        // ...

        // Method to analyze or process the activity
        public void AnalyzeActivity()
        {
            // Your logic to analyze the activity
        }
    }
}


