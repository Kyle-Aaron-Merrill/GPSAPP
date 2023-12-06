using DomainLayer.Models.User;
using DomainLayer.Models.PrivacySettings;

namespace ServiceLayer.CommonServices
{
    public interface IModelDataAnnotationCheck
    {
        void ValidateModelDataAnnotations<IDomainModel>(IDomainModel domainModel);
    }
}