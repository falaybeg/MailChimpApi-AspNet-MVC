using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailChimpApp.Models;
using MailChimpService.ApiServices;

namespace MailChimpApp.Controllers
{
    public class HomeController : Controller
    {
        MemberModel message = null;
        MembersApi member = new MembersApi();
        ListsApi lists = new ListsApi();

        public ActionResult Index()
        {
            return View();
        }
       

        public ActionResult AddSubscribe(string email)
        {
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

        public ActionResult List(string listId)
        {
            listId = "32a83f0ce0";
            lists.DeleteList(listId);

            return View("Index");
        }




    }
}