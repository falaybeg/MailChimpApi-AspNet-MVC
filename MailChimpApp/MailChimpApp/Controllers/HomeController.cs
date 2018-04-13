using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailChimp.Net.Models;
using MailChimpApp.Models;
using MailChimpService.ApiServices;

namespace MailChimpApp.Controllers
{
    public class HomeController : Controller
    {
        MembersApi member = new MembersApi();
        ListsApi list = new ListsApi();

        public ActionResult Index()
        {
            return View();
        }


        #region Members

        public ActionResult AddSubscribe(string email)
        {
            MemberModel message = null;
            if (email != null)
            {
                member.AddSubscribe("c97e72b500", email);

                message = new MemberModel
                {
                    TextMessage = "Thank you for Subscribing !"
                };
            }

            return View("AddSubscribe", message);
        }

        public ActionResult GetAllMember(string listId)
        {
            listId = "c97e72b500";
            var result = member.GetAllMember(listId);

            return View(result);
        }
        #endregion

        #region Lists

        public ActionResult AddList(List newList)
        {
            if (newList.Name != null)
            {
                newList.CampaignDefaults.Language = "en";
                newList.Contact.Country = "TR";
                newList.Contact.State = "";

                list.AddOrUpdateList(newList);
                return RedirectToAction("GetAllList");
            }

            return View("AddList");
        }

        public ActionResult GetAllList()
        {
            var result = list.GetAllLists();

            return View(result);
        }

        public ActionResult DeleteList(string listId)
        {
            listId = "32a83f0ce0";
            list.DeleteList(listId);

            return RedirectToAction("GetAllList");
        }

        #endregion





    }
}