using DomainLayer.Models.LocationPoint;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.LocationPointServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Test
{
    public class LocationPointFixture
    {
        private ILocationPointServices _locationPointServices;
        private ILocationPointModel _locationPointModel;

        public LocationPointFixture()
        {
            _locationPointModel = new LocationPointModel();
            _locationPointServices = new LocationPointServices(null, new ModelDataAnnotationCheck());
        }

        public LocationPointModel LocationPointModel
        {
            get { return (LocationPointModel)_locationPointModel; }
            set { _locationPointModel = value; }
        }

        public ILocationPointServices LocationPointServices
        {
            get { return _locationPointServices; }
            set { _locationPointServices = value; }
        }
    }
}
