using DomainLayer.Models.User;

namespace ServiceLayer.CommonServices
{
    public interface IModelDataAnnotationCheck
    {
        void ValidateModelDataAnnotations<IDomainModel>(IDomainModel domainModel);
    }
}