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
    public class ContentController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddOrUpdateContent(string campaignId, ContentRequest request = null)
        {
            Task<Content> result = null;
            if (campaignId != null)
                result = mailChimpManager.Content.AddOrUpdateAsync(campaignId, request);

            return View(result.Result);
        }


        public ActionResult GetContent(string campaignId)
        {
            Task<Content> result = null;
            if (campaignId != null)
                result = mailChimpManager.Content.GetAsync(campaignId);

            return View(result.Result);
        }
    }
}