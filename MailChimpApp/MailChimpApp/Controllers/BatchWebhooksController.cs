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
    public class BatchWebhooksController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

       
        public ActionResult AddBatchWebhook(string url)
        {
            Task<BatchWebHook> result = null;

            if (url != null)
                result = mailChimpManager.BatchWebHooks.AddAsync(url);

            return View(result.Result);
        }

        public ActionResult DeleteList(string batchWebHookId)
        {
            if (batchWebHookId != null)
                mailChimpManager.BatchWebHooks.DeleteAsync(batchWebHookId);

            return View();
        }

        public ActionResult GetAllBatchWebhooks(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<BatchWebHook>> result = null;
            result = mailChimpManager.BatchWebHooks.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetBatchWebhookResponse(QueryableBaseRequest request = null)
        {
            Task<BatchWebHookResponse> result = null;
            result = mailChimpManager.BatchWebHooks.GetResponseAsync(request);

            return View(result.Result);
        }


        public ActionResult UpdateBatchWebhook(string batchWebHookId, string url)
        {
            Task<BatchWebHook> result = null;

            if (batchWebHookId != null && url != null)
                result = mailChimpManager.BatchWebHooks.UpdateAsync(batchWebHookId, url);

            return View(result.Result);
        }
    }
}