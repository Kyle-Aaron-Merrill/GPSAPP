using DomainLayer.Models.User;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserServices
{
    public class UserServices : IUserService, IUserRepository
    {
        private IUserRepository _userRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public UserServices(IUserRepository userRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _userRepository = userRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void ValidateModel(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
