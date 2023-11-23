using System;

namespace DomainLayer.Models.Activity
{
    internal interface IActivityModel
    {
        int ActivityID { get; set; }
        string ActivityType { get; set; }
        double AverageSpeed { get; set; }
        double Distance { get; set; }
        TimeSpan Duration { get; set; }
        double ElevationGain { get; set; }
        DateTime EndTime { get; set; }
        DateTime StartTime { get; set; }
        int UserID { get; set; }

        void AnalyzeActivity();
    }
}