using DomainLayer.Models.APITokens;
using Newtonsoft.Json.Linq;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.ApiTokensServices;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Test
{
    [Trait("Category", "Model Validations")]
    public class ApiTokenServicesValidationTest : IClassFixture<ApiTokenServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private ApiTokenServicesFixture _apiTokenServicesFixture;

        public ApiTokenServicesValidationTest(ApiTokenServicesFixture apiTokenServicesFixture, ITestOutputHelper testOutputHelper)
        {
            _apiTokenServicesFixture = apiTokenServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldThrowExceptionForMissingUserID()
        {
            var apiTokensModel = new ApiTokensModel
            {
                // UserID is missing
                StravaAPIToken = "StravaToken",
                RideWithGPSAPIToken = "RideWithGPSToken",
                // Set other valid values
            };

            var exception = Assert.Throws<ArgumentException>(() => _apiTokenServicesFixture.ApiTokenServices.ValidateModelDataAnnotations(apiTokensModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldNotThrowExceptionForValidApiTokens()
        {
            var apiTokensModel = new ApiTokensModel
            {
                UserID = 1,
                StravaAPIToken = "StravaToken",
                RideWithGPSAPIToken = "RideWithGPSToken",
                // Set other valid values
            };

            var exception = Record.Exception(() => _apiTokenServicesFixture.ApiTokenServices.ValidateModelDataAnnotations(apiTokensModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidStravaAPITokenLength()
        {
            var apiTokensModel = new ApiTokensModel
            {
                UserID = 1,
                StravaAPIToken = new string('A', 256), // Exceeds maximum length
                RideWithGPSAPIToken = "RideWithGPSToken",
                // Set other valid values
            };

            var exception = Assert.Throws<ArgumentException>(() => _apiTokenServicesFixture.ApiTokenServices.ValidateModelDataAnnotations(apiTokensModel));
            WriteExceptionTestResult(exception);
        }

        // Add more test methods for other properties...

        private void SetValidSampleValues()
        {
            // Set valid values for testing
            _apiTokenServicesFixture.ApiTokenModel = new ApiTokensModel
            {
                UserID = 1,
                StravaAPIToken = "StravaToken",
                RideWithGPSAPIToken = "RideWithGPSToken",
                // Set other valid values for ApiTokensModel properties
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
                // Convert ApiTokensModel to JSON
                JObject json = JObject.FromObject(_apiTokenServicesFixture.ApiTokenModel);
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
