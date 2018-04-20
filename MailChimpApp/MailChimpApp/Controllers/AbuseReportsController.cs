using System;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.ApiManager;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class AbuseReportsController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        /// <summary>
        /// We can get abused list reports by listId
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetAllActivities(string listId, BaseRequest request = null)
        {
            Task<IEnumerable<Activity>> result = null;
            listId = "c97e72b500";
            if (listId != null)
                result = mailChimpManager.Activities.GetAllAsync(listId, request);

            return View(result.Result);
        }


        public ActionResult GetActivityResponse(string listId, BaseRequest request = null)
        {
            Task<ActivityResponse> result = null;

            if (listId != null)
                result = mailChimpManager.Activities.GetResponseAsync(listId, request);

            return View(result.Result);
        }
    }
}