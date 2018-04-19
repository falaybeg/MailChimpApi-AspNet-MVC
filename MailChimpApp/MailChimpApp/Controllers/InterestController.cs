using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.ApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class InterestController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddOrUpdateInterest(Interest list)
        {
            Task<Interest> result = null;

            if (list != null)
                result = mailChimpManager.Interests.AddOrUpdateAsync(list);

            return View(result.Result);
        }

        public ActionResult DeleteInterest(string listId, string interestCategoryId, string interestId)
        {
            if (listId != null && interestCategoryId != null && interestId != null)
                mailChimpManager.Interests.DeleteAsync(listId, interestCategoryId, interestId);

            return View();
        }

        public ActionResult GetAllInterest(string listId, string interestCategoryId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Interest>> result = null;

            if (listId != null && interestCategoryId != null)
                result = mailChimpManager.Interests.GetAllAsync(listId, interestCategoryId, request);

            return View(result.Result);
        }
        public ActionResult GetInterest(string listId, string interestCategoryId, string interestId, BaseRequest request = null)
        {
            Task<Interest> result = null;

            if (listId != null && interestCategoryId != null && interestId != null)
                result = mailChimpManager.Interests.GetAsync(listId, interestCategoryId, interestId, request);

            return View(result.Result);
        }

        public ActionResult GetInterestResponse(string listId, string interestCategoryId, InterestCategoryRequest request = null)
        {
            Task<InterestResponse> result = null;

            if (listId != null && interestCategoryId != null)
                result = mailChimpManager.Interests.GetResponseAsync(listId, interestCategoryId, request);

            return View(result.Result);
        }

        public ActionResult UpdateInterest(Interest list)
        {
            Task<Interest> result = null;

            if (list != null)
                result = mailChimpManager.Interests.UpdateAsync(list);

            return View(result.Result);
        }
    }
}