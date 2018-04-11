using MailChimpApp.ApiMailChimp;
using MailChimpApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class HomeController : Controller
    {
        MembersApi m = new MembersApi();
        ListsApi lists = new ListsApi();
        MemberModel message = null;

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddSubscribe(string email)
        {
            if (email != null)
            {
                m.AddSubscribe("c97e72b500", email);
                message = new MemberModel
                {
                    TextMessage = "Thank you for Subscribing !"
                };
            }

            return View("AddSubscribe",message);
        }


        public ActionResult GetAllMember(string listId)
        {
            listId = "c97e72b500";
            var result = m.GetAllMember(listId);

            return View(result);
        }

        public ActionResult List(string listId)
        {
            listId = "32a83f0ce0";
            lists.DeleteList(listId);

            return View("Index");
        }
    }
}