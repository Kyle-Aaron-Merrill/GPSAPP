using DomainLayer.Models.PrivacySettings;
using Newtonsoft.Json.Linq;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.PrivacySettingsServices;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Test
{
    [Trait("Category", "Model Validations")]
    public class PrivacySettingsServicesValidationTest : IClassFixture<PrivacySettingsServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private PrivacySettingsServicesFixture _privacySettingsServicesFixture;

        public PrivacySettingsServicesValidationTest(PrivacySettingsServicesFixture privacySettingsServicesFixture, ITestOutputHelper testOutputHelper)
        {
            _privacySettingsServicesFixture = privacySettingsServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldThrowExceptionForMissingUserId()
        {
            var privacySettingsModel = new PrivacySettingsModel
            {
                UserID = 0,
                IsPublic = true,
            };

            var exception = Record.Exception(() => _privacySettingsServicesFixture.PrivacySettingsServices.ValidateModelDataAnnotations(privacySettingsModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }



        [Fact]
        public void ShouldNotThrowExceptionForValidUserId()
        {
            var privacySettingsModel = new PrivacySettingsModel
            {
                UserID = 1,
                IsPublic = true,
                // Set other valid values
            };

            var exception = Record.Exception(() => _privacySettingsServicesFixture.PrivacySettingsServices.ValidateModelDataAnnotations(privacySettingsModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForMissingIsPublic()
        {
            var privacySettingsModel = new PrivacySettingsModel
            {
                UserID = 1, // Set a valid UserID
                // IsPublic is missing
            };

            var exception = Assert.Throws<ArgumentException>(() => _privacySettingsServicesFixture.PrivacySettingsServices.ValidateModelDataAnnotations(privacySettingsModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldNotThrowExceptionForValidIsPublic()
        {
            var privacySettingsModel = new PrivacySettingsModel
            {
                UserID = 1,
                IsPublic = true,
                // Set other valid values
            };

            var exception = Record.Exception(() => _privacySettingsServicesFixture.PrivacySettingsServices.ValidateModelDataAnnotations(privacySettingsModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidVisibleToFollowersLength()
        {
            var privacySettingsModel = new PrivacySettingsModel
            {
                UserID = 1,
                IsPublic = true,
                VisibleToFollowers = new string('A', 256) // Exceeds maximum length
            };

            var exception = Assert.Throws<ArgumentException>(() => _privacySettingsServicesFixture.PrivacySettingsServices.ValidateModelDataAnnotations(privacySettingsModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldNotThrowExceptionForValidVisibleToFollowersLength()
        {
            var privacySettingsModel = new PrivacySettingsModel
            {
                UserID = 1,
                IsPublic = true,
                VisibleToFollowers = new string('A', 255) // Maximum length
            };

            var exception = Record.Exception(() => _privacySettingsServicesFixture.PrivacySettingsServices.ValidateModelDataAnnotations(privacySettingsModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }


        private void SetValidSampleValues()
        {
            // Set valid values for testing
            _privacySettingsServicesFixture.PrivacySettingsModel = new PrivacySettingsModel
            {
                PrivacySettingsID = 1,
                UserID = 1,
                ShowActivityMap = false,
                ShowActivityStats = true,
                AllowComments = true,
                AllowLikes = false,
                IsPublic = false,
                VisibleToFollowers = "SampleVisibleToFollowers",
                LastUpdated = DateTime.Now,
                // Add other properties and their valid values...
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
                // Convert PrivacySettingsModel to JSON
                JObject json = JObject.FromObject(_privacySettingsServicesFixture.PrivacySettingsModel);
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
