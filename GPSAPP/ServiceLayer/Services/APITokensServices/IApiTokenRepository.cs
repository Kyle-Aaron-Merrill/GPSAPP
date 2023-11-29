using DomainLayer.Models.APITokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ApiTokensServices
{
    public interface IApiTokensRepository
    {
        void Add(IApiTokensModel apiTokensModel);
        void Delete(IApiTokensModel apiTokensModel);
        IEnumerable<ApiTokensModel> GetAll();
        ApiTokensModel GetById(int id);
        void Update(IApiTokensModel apiTokensModel);
        void ValidateModel(IApiTokensModel apiTokensModel);
    }
}
