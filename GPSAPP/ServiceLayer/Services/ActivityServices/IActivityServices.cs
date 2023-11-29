using DomainLayer.Models.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ActivityServices
{
    public interface IActivityServices
    {
        void ValidateModel(IActivityModel activityModel);
    }
}
