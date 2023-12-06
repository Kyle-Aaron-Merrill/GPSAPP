using DomainLayer.Models.PrivacySettings;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.PrivacySettingsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Test
{
    public class PrivacySettingsServicesFixture
    {
        private IPrivacySettingsServices _privacySettingsServices;
        private IPrivacySettingsModel _privacySettingsModel;

        public PrivacySettingsServicesFixture()
        {
            _privacySettingsModel = new PrivacySettingsModel();
            _privacySettingsServices = new PrivacySettingsServices(null, new ModelDataAnnotationCheck());
        }

        public PrivacySettingsModel PrivacySettingsModel
        {
            get { return (PrivacySettingsModel)_privacySettingsModel; }
            set { _privacySettingsModel = value; }
        }

        public IPrivacySettingsServices PrivacySettingsServices
        {
            get { return _privacySettingsServices; }
            set { _privacySettingsServices = value; }
        }
    }
}
