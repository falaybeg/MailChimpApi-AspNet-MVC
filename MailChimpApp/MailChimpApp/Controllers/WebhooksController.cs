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
    public class WebhooksController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddOrUpdateList(string listId, WebHook webhook)
        {
            Task<WebHook> result = null;

            if (listId != null && webhook != null)
                result = mailChimpManager.WebHooks.AddAsync(listId, webhook);

            return View(result.Result);
        }

        public ActionResult DeleteList(string listId, string webhookId)
        {
            if (listId != null && webhookId != null)
                mailChimpManager.WebHooks.DeleteAsync(listId, webhookId);

            return View();
        }

        public ActionResult GetAllWebhoks(string listId)
        {
            Task<IEnumerable<WebHook>> result = null;
            if (listId != null)
                result = mailChimpManager.WebHooks.GetAllAsync(listId);

            return View(result.Result);
        }

        public ActionResult GetList(string listId)
        {
            Task<WebHookResponse> result = null;
            if (listId != null)
                result = mailChimpManager.WebHooks.GetResponseAsync(listId);

            return View(result.Result);
        }

        public ActionResult GetList(string listId, MergeField mergeField, int? mergeId = null)
        {
            Task<MergeField> result = null;

            if (listId != null && mergeField != null)
                result = mailChimpManager.WebHooks.UpdateAsync(listId, mergeField, mergeId);

            return View(result.Result);
        }
    }
}