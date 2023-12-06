using DomainLayer.Models.LocationPoint;
using Newtonsoft.Json.Linq;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.LocationPointServices;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Test
{
    [Trait("Category", "Model Validations")]
    public class LocationPointServicesValidationTest : IClassFixture<LocationPointFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private LocationPointFixture _locationPointFixture;

        public LocationPointServicesValidationTest(LocationPointFixture locationPointFixture, ITestOutputHelper testOutputHelper)
        {
            _locationPointFixture = locationPointFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldThrowExceptionForMissingActivityID()
        {
            var locationPointModel = new LocationPointModel
            {
                // ActivityID is missing
                Latitude = 30.0,
                Longitude = -90.0,
                Altitude = 0.0,
                Timestamp = DateTime.Now,
                BatteryLevel = 80.0,
                PowerUsage = 10.0,
                HorizontalAccuracy = 5.0,
                VerticalAccuracy = 5.0,
                PopulationDensity = 100.0,
            };

            var exception = Assert.Throws<ArgumentException>(() => _locationPointFixture.LocationPointServices.ValidateModelDataAnnotations(locationPointModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldNotThrowExceptionForValidLocationPoint()
        {
            var locationPointModel = new LocationPointModel
            {
                ActivityID = 1,
                Latitude = 30.0,
                Longitude = -90.0,
                Altitude = 0.0,
                Timestamp = DateTime.Now,
                BatteryLevel = 80.0,
                PowerUsage = 10.0,
                HorizontalAccuracy = 5.0,
                VerticalAccuracy = 5.0,
                PopulationDensity = 100.0,
                // Set other valid values
            };

            var exception = Record.Exception(() => _locationPointFixture.LocationPointServices.ValidateModelDataAnnotations(locationPointModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidLatitudeRange()
        {
            var locationPointModel = new LocationPointModel
            {
                ActivityID = 1,
                Latitude = 100.0, // Invalid latitude range
                Longitude = -90.0,
                Altitude = 0.0,
                Timestamp = DateTime.Now,
                BatteryLevel = 80.0,
                PowerUsage = 10.0,
                HorizontalAccuracy = 5.0,
                VerticalAccuracy = 5.0,
                PopulationDensity = 100.0,
            };

            var exception = Assert.Throws<ArgumentException>(() => _locationPointFixture.LocationPointServices.ValidateModelDataAnnotations(locationPointModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForMissingLongitude()
        {
            var locationPointModel = new LocationPointModel
            {
                ActivityID = 1,
                Latitude = 30.0,
                // Longitude is missing
                Altitude = 0.0,
                Timestamp = DateTime.Now,
                BatteryLevel = 80.0,
                PowerUsage = 10.0,
                HorizontalAccuracy = 5.0,
                VerticalAccuracy = 5.0,
                PopulationDensity = 100.0,
            };

            var exception = Assert.Throws<ArgumentException>(() => _locationPointFixture.LocationPointServices.ValidateModelDataAnnotations(locationPointModel));
            WriteExceptionTestResult(exception);
        }

        // Add more test methods for other properties...

        private void SetValidSampleValues()
        {
            // Set valid values for testing
            _locationPointFixture.LocationPointModel = new LocationPointModel
            {
                ActivityID = 1,
                Latitude = 30.0,
                Longitude = -90.0,
                Altitude = 0.0,
                Timestamp = DateTime.Now,
                BatteryLevel = 80.0,
                PowerUsage = 10.0,
                HorizontalAccuracy = 5.0,
                VerticalAccuracy = 5.0,
                PopulationDensity = 100.0,
                // Set other valid values for LocationPointModel properties
            };
        }

        private void WriteExceptionTestResult(Exception exception)
        {
            if (exception != null)
            {
                _testOutputHelper.WriteLine(exception.Message);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                // Convert LocationPointModel to JSON
                JObject json = JObject.FromObject(_locationPointFixture.LocationPointModel);
                stringBuilder.Append("***** No Exception Was Thrown *****").AppendLine();
                foreach (JProperty jProperty in json.Properties())
                {
                    stringBuilder.Append(jProperty.Name).Append(" --> ").Append(jProperty.Value).AppendLine();
                }

                _testOutputHelper.WriteLine(stringBuilder.ToString());
            }
        }
    }
}
