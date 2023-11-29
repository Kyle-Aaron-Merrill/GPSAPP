using DomainLayer.Models.PrivacySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.PrivacySettingsServices
{
    public interface IPrivacySettingsServices
    {
        void ValidateModel(IPrivacySettingsModel privacySettingsModel);
    }
}