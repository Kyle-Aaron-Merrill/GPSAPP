using DomainLayer.Models.Activity;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ActivityServices
{
    public class ActivityServices : IActivityRepository, IActivityServices
    {
        private IActivityRepository _activityRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ActivityServices(IActivityRepository activityRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _activityRepository = activityRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(IActivityModel activityModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(IActivityModel activityModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ActivityModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IActivityModel activityModel)
        {
            throw new NotImplementedException();
        }

        public void ValidateModel(IActivityModel activityModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(activityModel);
            // Additional validation specific to Activity
        }

        /*
        For the `ActivityServices` related to user activities, you might consider additional services or features depending on the requirements of your application. Here are some suggestions:

        1. **Filtering Activities:**
           - Allow users to filter their activities based on criteria such as date, type, or category.

        2. **Activity Feed:**
           - Implement an activity feed service that retrieves a list of recent activities for a user or a group of users.

        3. **User Interactions:**
           - Record and manage user interactions, such as likes, comments, or shares on specific activities.

        4. **Notification Services:**
           - Implement services to generate notifications for users based on their activities or interactions.

        5. **Reporting:**
           - Provide reporting services to analyze and generate reports on user activities over a specific period.

        6. **Trending Activities:**
           - Identify and display trending or popular activities based on user engagement.

        7. **Location-Based Activities:**
           - If applicable, implement services related to activities with location data, such as check-ins or location-based updates.

        8. **User Activity Analytics:**
           - Provide analytics services to track and analyze user activity patterns for insights.

        9. **User Statistics:**
           - Calculate and display user statistics, such as the number of activities performed, average activity frequency, etc.

        10. **Integration with Other Modules:**
            - Integrate activity services with other modules or features, such as user profiles, achievements, or rewards.

        Remember, the specific services you implement will depend on the goals and functionalities of your application. Adjust and expand these suggestions based on the unique requirements of your project.
        */

    }
}
