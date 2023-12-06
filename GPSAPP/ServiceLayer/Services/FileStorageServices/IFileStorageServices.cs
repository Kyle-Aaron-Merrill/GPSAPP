using DomainLayer.Models.FileStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.FileStorageServices
{
    public interface IFileStorageServices
    {
        void ValidateModel(IFileStorageModel fileStorageModel);
        void ValidateModelDataAnnotations(IFileStorageModel fileStorageModel);
    }
}
