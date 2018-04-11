using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MailChimpApp.ApiMailChimp
{
    public class ActivitiesApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public IEnumerable<Activity> GetAllActivities(string listId, BaseRequest request = null)
        {
            Task<IEnumerable<Activity>> result = null;

            if (listId != null)
                result = mailChimpManager.Activities.GetAllAsync(listId, request);

            return result.Result;
        }


        public ActivityResponse GetActivityResponse(string listId, BaseRequest request = null)
        {
            Task<ActivityResponse> result = null;

            if (listId != null)
                result = mailChimpManager.Activities.GetResponseAsync(listId, request);

            return result.Result;
        }
    }
}