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
    public class ActivitiesController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult GetRemovedSubsribers(string workflowId)
        {
            Task<IEnumerable<Subscriber>> result = null;

            if (workflowId != null)
                result = mailChimpManager.AutomationSubscribers.GetRemovedSubscribersAsync(workflowId);

            return View(result.Result);
        }
        public ActionResult GetRemovedSubsribersResponse(string workflowId)
        {
            Task<AutomationSubscriberResponse> result = null;

            if (workflowId != null)
                result = mailChimpManager.AutomationSubscribers.GetRemovedSubscribersResponseAsync(workflowId);

            return View(result.Result);
        }

        public ActionResult RemoveAutomationSubscriber(string workflowId, string emailAddress)
        {
            Task<Subscriber> result = null;

            if (workflowId != null && emailAddress != null)
                result = mailChimpManager.AutomationSubscribers.RemoveSubscriberAsync(workflowId, emailAddress);

            return View(result.Result);
        }

    }
}