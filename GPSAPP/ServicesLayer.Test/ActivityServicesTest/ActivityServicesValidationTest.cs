using DomainLayer.Models.Activity;
using Newtonsoft.Json.Linq;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.ActivityServices;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Test
{
    [Trait("Category", "Model Validations")]
    public class ActivityServicesValidationTest : IClassFixture<ActivityServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private ActivityServicesFixture _activityServicesFixture;

        public ActivityServicesValidationTest(ActivityServicesFixture activityServicesFixture, ITestOutputHelper testOutputHelper)
        {
            _activityServicesFixture = activityServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldThrowExceptionForMissingUserID()
        {
            var activityModel = new ActivityModel
            {
                // UserID is missing
                ActivityType = "Running",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                Distance = 10.0,
                Duration = TimeSpan.FromMinutes(60),
                AverageSpeed = 10.0,
                ElevationGain = 100.0,
                // Set other valid values
            };

            var exception = Assert.Throws<ArgumentException>(() => _activityServicesFixture.ActivityServices.ValidateModelDataAnnotations(activityModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldNotThrowExceptionForValidActivity()
        {
            var activityModel = new ActivityModel
            {
                UserID = 1,
                ActivityType = "Running",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                Distance = 10.0,
                Duration = TimeSpan.FromMinutes(60),
                AverageSpeed = 10.0,
                ElevationGain = 100.0,
                // Set other valid values
            };

            var exception = Record.Exception(() => _activityServicesFixture.ActivityServices.ValidateModelDataAnnotations(activityModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidActivityTypeLength()
        {
            var activityModel = new ActivityModel
            {
                UserID = 1,
                ActivityType = new string('A', 51), // Exceeds maximum length
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                Distance = 10.0,
                Duration = TimeSpan.FromMinutes(60),
                AverageSpeed = 10.0,
                ElevationGain = 100.0,
                // Set other valid values
            };

            var exception = Assert.Throws<ArgumentException>(() => _activityServicesFixture.ActivityServices.ValidateModelDataAnnotations(activityModel));
            WriteExceptionTestResult(exception);
        }

        // Add more test methods for other properties...

        private void SetValidSampleValues()
        {
            // Set valid values for testing
            _activityServicesFixture.ActivityModel = new ActivityModel
            {
                UserID = 1,
                ActivityType = "Running",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                Distance = 10.0,
                Duration = TimeSpan.FromMinutes(60),
                AverageSpeed = 10.0,
                ElevationGain = 100.0,
                // Set other valid values for ActivityModel properties
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
                // Convert ActivityModel to JSON
                JObject json = JObject.FromObject(_activityServicesFixture.ActivityModel);
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
