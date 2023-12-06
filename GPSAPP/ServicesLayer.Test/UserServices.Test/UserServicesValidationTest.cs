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

        [Fact]
        public void ShouldPassValidationForValidUsername()
        {
            _userServicesFixture.UserModel.Username = "john.doe";

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidUsername()
        {
            _userServicesFixture.UserModel.Username = "jd"; // Assume this is shorter than the required length.

            var exception = Assert.Throws<ArgumentException>(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldPassValidationForValidRole()
        {
            _userServicesFixture.UserModel.Role = "User";

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidRole()
        {
            _userServicesFixture.UserModel.Role = "AdministratorWithAnUnnecessarilyLongRoleNameThatHasMoreThan50Chars"; // Assume this is longer than the allowed length.

            var exception = Assert.Throws<ArgumentException>(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldPassValidationForValidDateOfBirth()
        {
            _userServicesFixture.UserModel.DateOfBirth = new DateTime(1990, 1, 1);

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidDateOfBirth()
        {
            _userServicesFixture.UserModel.DateOfBirth = DateTime.Today.AddDays(1);

            var exception = Assert.Throws<ArgumentException>(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldPassValidationForValidZipCode()
        {
            _userServicesFixture.UserModel.ZipCode = "12345";

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidZipCode()
        {
            _userServicesFixture.UserModel.ZipCode = "invalidZipCode";

            var exception = Assert.Throws<ArgumentException>(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldPassValidationForValidAge()
        {
            _userServicesFixture.UserModel.Age = 25;

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidAge()
        {
            _userServicesFixture.UserModel.Age = -5; // Assume this is a negative age.

            var exception = Assert.Throws<ArgumentException>(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldPassValidationForValidPhoneNumber()
        {
            _userServicesFixture.UserModel.PhoneNumber = "123-456-7890";

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidPhoneNumber()
        {
            _userServicesFixture.UserModel.PhoneNumber = "invalidPhoneNumber";

            var exception = Assert.Throws<ArgumentException>(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldPassValidationForValidCreditCardNumber()
        {
            _userServicesFixture.UserModel.CreditCardNumber = "4234-5678-9012-3456";

            var exception = Record.Exception(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidCreditCardNumber()
        {
            _userServicesFixture.UserModel.CreditCardNumber = "invalidCreditCardNumber";

            var exception = Assert.Throws<ArgumentException>(() => _userServicesFixture.UserServices.ValidateModelDataAnnotations(_userServicesFixture.UserModel));
            WriteExceptionTestResult(exception);
        }

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
                DateOfBirth = new DateTime(1990,1,1),
                ZipCode = "12345",
                Age = 30,
                PhoneNumber = "123-456-7890",
                Website = "http://www.example.com",
                CreditCardNumber = "4234-5678-9012-3456",
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
