using DomainLayer.Models.FileStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FileStorageServices
{
    public interface IFileStorageRepository
    {
        void UploadFile(IFileStorageModel fileStorageModel);
        void DeleteFile(string fileId);
        IEnumerable<FileStorageModel> GetAllFiles();
        FileStorageModel GetFileById(string fileId);
        void UpdateFile(IFileStorageModel fileStorageModel);
        void ValidateModel(IFileStorageModel fileStorageModel);
    }
}
