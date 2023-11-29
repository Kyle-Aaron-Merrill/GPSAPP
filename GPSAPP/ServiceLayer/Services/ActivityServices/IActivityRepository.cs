using DomainLayer.Models.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ActivityServices
{
    public interface IActivityRepository
    {
        void Add(IActivityModel activityModel);
        void Delete(IActivityModel activityModel);
        IEnumerable<ActivityModel> GetAll();
        ActivityModel GetById(int id);
        void Update(IActivityModel activityModel);
        void ValidateModel(IActivityModel activityModel);
    }
}
