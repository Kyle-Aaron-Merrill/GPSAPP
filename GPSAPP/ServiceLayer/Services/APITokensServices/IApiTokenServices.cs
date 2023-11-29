using DomainLayer.Models.APITokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ApiTokensServices
{
    public interface IApiTokensServices
    {
        void ValidateModel(IApiTokensModel apiTokensModel);
    }
}
