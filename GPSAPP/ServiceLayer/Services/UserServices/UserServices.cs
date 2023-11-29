using DomainLayer.Models.Activity;
using DomainLayer.Models.User;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserServices
{
    public class UserServices : IUserServices, IUserRepository
    {
        private IUserRepository _userRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public UserServices(IUserRepository userRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _userRepository = userRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(IUserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(IUserModel userModel)
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

        public void Update(IUserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void ValidateModel(IUserModel userModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(userModel);
            ValidateUserUrl(userModel);
        }

        public void ValidateModelDataAnnotations(IUserModel userModel) 
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(userModel);
        }

        public void ValidateUserUrl(IUserModel userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<IUserModel> SearchUsers(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUserModel> FilterUsers(Func<IUserModel, bool> filterCriteria)
        {
            throw new NotImplementedException();
        }

        public IUserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(IUserModel userModel, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityModel> GetUserActivities(int userId)
        {
            throw new NotImplementedException();
        }

        public void ValidateUserEmail(IUserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void LockUserAccount(IUserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void UnlockUserAccount(IUserModel userModel)
        {
            throw new NotImplementedException();
        }

        public string GenerateUserReport(int userId)
        {
            throw new NotImplementedException();
        }

        public void ExportUsersToCsv(IEnumerable<IUserModel> users, string filePath)
        {
            throw new NotImplementedException();
        }

    }
}
