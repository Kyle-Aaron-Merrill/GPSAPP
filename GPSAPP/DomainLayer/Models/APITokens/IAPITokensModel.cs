using System;

namespace DomainLayer.Models.APITokens
{
    internal interface IAPITokensModel
    {
        string AccelerometerAPIToken { get; set; }
        int APITokenID { get; set; }
        string GoogleMapsAPIToken { get; set; }
        string GPSLoggerAPIToken { get; set; }
        string PopulationDensityAPIToken { get; set; }
        string RideWithGPSAPIToken { get; set; }
        DateTime RideWithGPSTokenExpiration { get; set; }
        string StravaAPIToken { get; set; }
        DateTime StravaTokenExpiration { get; set; }
        int UserID { get; set; }

        void RefreshTokens();
    }
}