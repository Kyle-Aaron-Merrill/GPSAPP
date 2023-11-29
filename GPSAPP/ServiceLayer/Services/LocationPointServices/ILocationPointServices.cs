using DomainLayer.Models.LocationPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.LocationPointServices
{
    public interface ILocationPointServices
    {
        void ValidateModel(ILocationPointModel locationPointModel);
    }
}