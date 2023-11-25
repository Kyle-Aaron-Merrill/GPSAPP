using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserServices
{
    public interface IUserRepository
    {
        void Add(UserModel userModel);
        void Update(UserModel userModel);
        void Delete(UserModel userModel);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
    }
}
