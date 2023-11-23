using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.FileStorage
{
    internal class FileStorageModel : IFileStorageModel
    {
        public int FileID { get; set; }

        // Reference to the associated activity
        [Required(ErrorMessage = "ActivityID is required.")]
        public int ActivityID { get; set; }

        // File type (e.g., GPX, photo)
        [Required(ErrorMessage = "FileType is required.")]
        [StringLength(50, ErrorMessage = "FileType must be at most 50 characters.")]
        public string FileType { get; set; }

        // File path or reference to the file storage system
        [Required(ErrorMessage = "FilePath is required.")]
        [StringLength(255, ErrorMessage = "FilePath must be at most 255 characters.")]
        public string FilePath { get; set; }

        // Metadata related to the file
        [Required(ErrorMessage = "FileName is required.")]
        [StringLength(255, ErrorMessage = "FileName must be at most 255 characters.")]
        public string FileName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "FileSize must be a non-negative value.")]
        public long FileSize { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; }

        // Other properties for future considerations
        // [StringLength] or other annotations as needed
        // public string Description { get; set; }
        // ...

        // Method to validate or process the file
        public void ProcessFile()
        {
            // Your logic to process the file
        }
    }
}


