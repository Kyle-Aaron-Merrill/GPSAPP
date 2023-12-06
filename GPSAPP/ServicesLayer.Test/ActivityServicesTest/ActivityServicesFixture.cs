using DomainLayer.Models.Activity;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.ActivityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Test
{
    public class ActivityServicesFixture
    {
        private IActivityServices _activityServices;
        private IActivityModel _activityModel;

        public ActivityServicesFixture()
        {
            _activityModel = new ActivityModel();
            _activityServices = new ActivityServices(null, new ModelDataAnnotationCheck());
        }

        public ActivityModel ActivityModel
        {
            get { return (ActivityModel)_activityModel; }
            set { _activityModel = value; }
        }

        public IActivityServices ActivityServices
        {
            get { return _activityServices; }
            set { _activityServices = value; }
        }
    }
}
