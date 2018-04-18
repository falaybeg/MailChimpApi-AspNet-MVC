using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailChimpApp.ApiManager;
using System.Threading.Tasks;

namespace MailChimpApp.Controllers
{
    public class ListController : Controller
    {
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
            // Get List Information
            Task<List> result = null;
            if (listId != null)
                result = mailChimpManager.Lists.GetAsync(listId);

            return View(result.Result);

        }

        public ActionResult GetList(string listId)
        {
            // Get List Member 

            Task<IEnumerable<Member>> result = null;
            if (listId != null)
                result = mailChimpManager.Members.GetAllAsync(listId);

            return View(result.Result.Select(x => x.Status == Status.Subscribed));
        }

        

    }
}