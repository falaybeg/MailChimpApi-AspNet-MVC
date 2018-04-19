using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailChimp.Net;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.Models;

namespace MailChimpApp.Controllers
{
    public class HomeController : Controller
    { 

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult AddList(List newList)
        //{
        //    if (newList.Name != null)
        //    {
        //        newList.CampaignDefaults.Language = "en";
        //        newList.Contact.Country = "TR";
        //        newList.Contact.State = "";

        //        list.AddOrUpdateList(newList);
        //        return RedirectToAction("GetAllList");
        //    }

        //    return View("AddList");
        //}

    }
}