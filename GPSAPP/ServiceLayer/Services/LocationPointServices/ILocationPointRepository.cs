using DomainLayer.Models.LocationPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.LocationPointServices
{
    public interface ILocationPointRepository
    {
        void Add(ILocationPointModel locationPointModel);
        void Delete(ILocationPointModel locationPointModel);
        IEnumerable<LocationPointModel> GetAll();
        LocationPointModel GetById(int id);
        void Update(ILocationPointModel locationPointModel);
        void ValidateModel(ILocationPointModel locationPointModel);
    }
}
