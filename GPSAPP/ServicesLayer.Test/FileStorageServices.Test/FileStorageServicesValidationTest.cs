using DomainLayer.Models.FileStorage;
using Newtonsoft.Json.Linq;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.FileStorageServices;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Test
{
    [Trait("Category", "Model Validations")]
    public class FileStorageServicesValidationTest : IClassFixture<FileStorageFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private FileStorageFixture _fileStorageFixture;

        public FileStorageServicesValidationTest(FileStorageFixture fileStorageFixture, ITestOutputHelper testOutputHelper)
        {
            _fileStorageFixture = fileStorageFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldThrowExceptionForMissingActivityID()
        {
            var fileStorageModel = new FileStorageModel
            {
                // ActivityID is missing
                FileType = "GPX",
                FilePath = "/path/to/file",
                FileName = "example.gpx",
                FileSize = 1024,
                UploadDate = DateTime.Now,
                // Set other valid values
            };

            var exception = Assert.Throws<ArgumentException>(() => _fileStorageFixture.FileStorageServices.ValidateModelDataAnnotations(fileStorageModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldNotThrowExceptionForValidFileStorage()
        {
            var fileStorageModel = new FileStorageModel
            {
                ActivityID = 1,
                FileType = "GPX",
                FilePath = "/path/to/file",
                FileName = "example.gpx",
                FileSize = 1024,
                UploadDate = DateTime.Now,
                // Set other valid values
            };

            var exception = Record.Exception(() => _fileStorageFixture.FileStorageServices.ValidateModelDataAnnotations(fileStorageModel));
            Assert.Null(exception);
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForMissingFileType()
        {
            var fileStorageModel = new FileStorageModel
            {
                ActivityID = 1,
                // FileType is missing
                FilePath = "/path/to/file",
                FileName = "example.gpx",
                FileSize = 1024,
                UploadDate = DateTime.Now,
                // Set other valid values
            };

            var exception = Assert.Throws<ArgumentException>(() => _fileStorageFixture.FileStorageServices.ValidateModelDataAnnotations(fileStorageModel));
            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidFileSize()
        {
            var fileStorageModel = new FileStorageModel
            {
                ActivityID = 1,
                FileType = "GPX",
                FilePath = "/path/to/file",
                FileName = "example.gpx",
                FileSize = -1, // Invalid file size
                UploadDate = DateTime.Now,
                // Set other valid values
            };

            var exception = Assert.Throws<ArgumentException>(() => _fileStorageFixture.FileStorageServices.ValidateModelDataAnnotations(fileStorageModel));
            WriteExceptionTestResult(exception);
        }

        // Add more test methods for other properties...

        private void SetValidSampleValues()
        {
            // Set valid values for testing
            _fileStorageFixture.FileStorageModel = new FileStorageModel
            {
                ActivityID = 1,
                FileType = "GPX",
                FilePath = "/path/to/file",
                FileName = "example.gpx",
                FileSize = 1024,
                UploadDate = DateTime.Now,
                // Set other valid values for FileStorageModel properties
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
                // Convert FileStorageModel to JSON
                JObject json = JObject.FromObject(_fileStorageFixture.FileStorageModel);
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
