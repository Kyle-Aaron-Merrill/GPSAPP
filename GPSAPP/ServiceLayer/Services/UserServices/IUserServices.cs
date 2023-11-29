using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserServices
{
    public interface IUserServices
    {
        void ValidateModel(IUserModel userModel);
        void ValidateModelDataAnnotations(IUserModel userModel);
        void ValidateUserUrl(IUserModel userModel);
    }
}
