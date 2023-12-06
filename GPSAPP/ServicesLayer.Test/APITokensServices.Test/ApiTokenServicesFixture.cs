using DomainLayer.Models.APITokens;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.ApiTokensServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Test
{
    public class ApiTokenServicesFixture
    {
        private IApiTokensServices _apiTokenServices;
        private IApiTokensModel _apiTokenModel;

        public ApiTokenServicesFixture()
        {
            _apiTokenModel = new ApiTokensModel();
            _apiTokenServices = new ApiTokensServices(null, new ModelDataAnnotationCheck());
        }

        public ApiTokensModel ApiTokenModel
        {
            get { return (ApiTokensModel)_apiTokenModel; }
            set { _apiTokenModel = value; }
        }

        public IApiTokensServices ApiTokenServices
        {
            get { return _apiTokenServices; }
            set { _apiTokenServices = value; }
        }
    }
}
