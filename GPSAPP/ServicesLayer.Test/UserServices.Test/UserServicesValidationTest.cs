using DomainLayer.Models.User;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Test
{
    [Trait("Category", "Model Validations")]
    public class UserServicesValidationTest : IClassFixture<UserServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private UserServicesFixture _userServicesFixture;

        public UserServicesValidationTest(UserServicesFixture userServicesFixture, ITestOutputHelper testOutputHelper)
        {
            this._userServicesFixture = userServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
        {
            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionIfAnyDataAnnotationCheckFails()
        {
            _userServicesFixture.UserModel.PhoneNumber = "321-444-333q";
            _userServicesFixture.UserModel.Email = "janet4trail.com";

            Exception exception = Assert.Throws<ArgumentException>(() =>
                _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldPassValidationForValidEmails()
        {
            _userServicesFixture.UserModel.Email = "john.doe@example.com";

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidEmails()
        {
            _userServicesFixture.UserModel.Email = "invalid.email";

            Exception exception = Assert.Throws<ArgumentException>(() =>
                _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldPassValidationForStrongPasswords()
        {
            _userServicesFixture.UserModel.Password = "StrongPassword123";

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForWeakPasswords()
        {
            _userServicesFixture.UserModel.Password = "weak";

            Exception exception = Assert.Throws<ArgumentException>(() =>
                _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));

            WriteExceptionTestResult(exception);
        }

        // Add similar tests for DateOfBirth, ZipCode, Age, PhoneNumber, Website, CreditCardNumber, Role, and other properties...

        private void SetValidSampleValues()
        {
            // Set valid values for testing
            _userServicesFixture.UserModel = new UserModel
            {
                UserID = 1,
                Username = "john.doe",
                Password = "StrongPassword123",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Role = "User",
                DateOfBirth = new DateTime(1990, 1, 1),
                ZipCode = "12345",
                Age = 30,
                PhoneNumber = "123-456-7890",
                Website = "http://www.example.com",
                CreditCardNumber = "1234-5678-9012-3456",
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
                JObject json = JObject.FromObject(_userServicesFixture.UserModel);
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
