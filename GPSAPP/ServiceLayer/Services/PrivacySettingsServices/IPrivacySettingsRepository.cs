using DomainLayer.Models.PrivacySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.PrivacySettingsServices
{
    public interface IPrivacySettingsRepository 
    {
        void Add(IPrivacySettingsModel privacySettingsModel);
        void Delete(IPrivacySettingsModel privacySettingsModel);
        IEnumerable<PrivacySettingsModel> GetAll();
        PrivacySettingsModel GetById(int id);
        void Update(IPrivacySettingsModel privacySettingsModel);
        void ValidateModel(IPrivacySettingsModel privacySettingsModel);
    }
}
