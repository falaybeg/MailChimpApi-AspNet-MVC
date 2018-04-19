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
    public class InterestCategoriesController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddOrUpdateCategory(InterestCategory category, string listId)
        {
            Task<InterestCategory> result = null;

            if (category != null && listId != null)
                result = mailChimpManager.InterestCategories.AddOrUpdateAsync(category, listId);

            return View(result.Result);
        }

        public ActionResult DeleteList(string listId, string categoryId)
        {
            if (listId != null && categoryId != null)
                mailChimpManager.InterestCategories.DeleteAsync(listId, categoryId);

            return View();
        }

        public ActionResult GetAllCategories(string listId, InterestCategoryRequest request = null)
        {
            Task<IEnumerable<InterestCategory>> result = null;
            if (listId != null)
                result = mailChimpManager.InterestCategories.GetAllAsync(listId, request);

            return View(result.Result);
        }
        public ActionResult GetCategory(string listId, string categoryId)
        {
            Task<InterestCategory> result = null;

            if (listId != null && categoryId != null)
                result = mailChimpManager.InterestCategories.GetAsync(listId, categoryId);

            return View(result.Result);
        }

        public ActionResult GetCategoryResponse(string listId, InterestCategoryRequest request = null)
        {
            Task<InterestCategoryResponse> result = null;

            if (listId != null)
                result = mailChimpManager.InterestCategories.GetResponseAsync(listId, request);

            return View(result.Result);
        }
    }
}