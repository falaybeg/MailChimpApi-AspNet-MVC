using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailChimpApp.ApiManager;
using System.Threading.Tasks;
using MailChimp.Net.Core;

namespace MailChimpApp.Controllers
{
    public class ListController : Controller
    {

        /// <summary>
        /// Here we can manage our lists. Create a new list, delete, update... etc. 
        /// Also we can get information about our lists
        /// </summary>

        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddList(List newList)
        {
            if (newList.Name != null)
            {
                newList.CampaignDefaults.Language = "en";
                newList.Contact.Country = "TR";
                newList.Contact.State = "";

                mailChimpManager.Lists.AddOrUpdateAsync(newList);

                return RedirectToAction("GetAllList");
            }
            return View();
        }

        public ActionResult DeleteList(string listId)
        {
            mailChimpManager.Lists.DeleteAsync(listId);

            return RedirectToAction("GetAllList");
        }

        public ActionResult GetAllList()
        {
            Task<IEnumerable<List>> result = null;
            result = mailChimpManager.Lists.GetAllAsync();
            return View(result.Result);
        }

        public ActionResult GetListInfo(string listId)
        {
            Task<List> result = null;
            if (listId != null)
                result = mailChimpManager.Lists.GetAsync(listId);

            return View(result.Result);
        }

        public ActionResult GetList(string listId)
        {
            Task<IEnumerable<Member>> result = null;
            if (listId != null)
                result = mailChimpManager.Members.GetAllAsync(listId);

            return View(result.Result.Select(x => x.Status == Status.Subscribed));
        }

        public ActionResult GetListResponse(ListRequest request = null)
        {
            Task<ListResponse> result = null;
            result = mailChimpManager.Lists.GetResponseAsync(request);

            return View(result.Result);
        }

    }
}