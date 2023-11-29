using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.APITokens
{
    public class ApiTokensModel : IApiTokensModel
    {
        public int APITokenID { get; set; }

        // User-related information
        [Required(ErrorMessage = "UserID is required.")]
        public int UserID { get; set; }

        // API-specific tokens
        [StringLength(255, ErrorMessage = "StravaAPIToken must be at most 255 characters.")]
        public string StravaAPIToken { get; set; }

        [StringLength(255, ErrorMessage = "RideWithGPSAPIToken must be at most 255 characters.")]
        public string RideWithGPSAPIToken { get; set; }

        // Add more properties for other API tokens

        // Population density data API tokens
        [StringLength(255, ErrorMessage = "PopulationDensityAPIToken must be at most 255 characters.")]
        public string PopulationDensityAPIToken { get; set; }

        // Accelerometer data API tokens
        [StringLength(255, ErrorMessage = "AccelerometerAPIToken must be at most 255 characters.")]
        public string AccelerometerAPIToken { get; set; }

        // Google Maps API token
        [StringLength(255, ErrorMessage = "GoogleMapsAPIToken must be at most 255 characters.")]
        public string GoogleMapsAPIToken { get; set; }

        // GPS logger data API token
        [StringLength(255, ErrorMessage = "GPSLoggerAPIToken must be at most 255 characters.")]
        public string GPSLoggerAPIToken { get; set; }

        // Other properties for future considerations
        // [StringLength] or other annotations as needed
        // public string AdditionalToken1 { get; set; }
        // public string AdditionalToken2 { get; set; }
        // ...

        // Expiration dates or other relevant information
        public DateTime StravaTokenExpiration { get; set; }
        public DateTime RideWithGPSTokenExpiration { get; set; }

        // Add more expiration properties for other tokens

        // Method to refresh or manage token expiration
        public void RefreshTokens()
        {
            // Your logic to refresh tokens
        }
    }
}

