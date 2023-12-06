using DomainLayer.Models.FileStorage;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.FileStorageServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Test
{
    public class FileStorageFixture
    {
        private IFileStorageServices _fileStorageServices;
        private IFileStorageModel _fileStorageModel;

        public FileStorageFixture()
        {
            _fileStorageModel = new FileStorageModel();
            _fileStorageServices = new FileStorageServices(null, new ModelDataAnnotationCheck());
        }

        public FileStorageModel FileStorageModel
        {
            get { return (FileStorageModel)_fileStorageModel; }
            set { _fileStorageModel = value; }
        }

        public IFileStorageServices FileStorageServices
        {
            get { return _fileStorageServices; }
            set { _fileStorageServices = value; }
        }
    }
}
