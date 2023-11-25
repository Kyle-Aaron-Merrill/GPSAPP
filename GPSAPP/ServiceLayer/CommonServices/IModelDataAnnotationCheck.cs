namespace ServiceLayer.CommonServices
{
    public interface IModelDataAnnotationCheck
    {
        void ValidateModel<IDomainModel>(IDomainModel domainModel);
    }
}