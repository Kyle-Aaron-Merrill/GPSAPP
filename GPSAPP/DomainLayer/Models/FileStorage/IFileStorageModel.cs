using System;

namespace DomainLayer.Models.FileStorage
{
    public interface IFileStorageModel
    {
        int? ActivityID { get; set; }
        int FileID { get; set; }
        string FileName { get; set; }
        string FilePath { get; set; }
        long FileSize { get; set; }
        string FileType { get; set; }
        DateTime UploadDate { get; set; }

        void ProcessFile();
    }
}