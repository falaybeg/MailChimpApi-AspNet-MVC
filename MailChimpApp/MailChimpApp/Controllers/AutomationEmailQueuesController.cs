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
    public class AutomationEmailQueuesController : Controller
    {

        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddSubscriber(string workflowId, string workflowEmailId, string emailAddress)
        {
            Task<Queue> result = null;
            if (workflowId != null && workflowEmailId != null && emailAddress != null)
                mailChimpManager.AutomationEmailQueues.AddSubscriberAsync(workflowId, workflowEmailId, emailAddress);
            
            return View(result.Result);
        }

        public ActionResult GetAllAutomationEmailQueues(string workflowId, string workflowEmailId)
        {
            Task<IEnumerable<Queue>> result = null;
            if (workflowId != null && workflowEmailId != null)
                result = mailChimpManager.AutomationEmailQueues.GetAllAsync(workflowId, workflowEmailId);

            return View(result.Result);
        }

        public ActionResult GetAutomationEmailQueue(string workflowId, string workflowEmailId, string emailAddressOrHash)
        {
            Task<Queue> result = null;
            if (workflowId != null && workflowEmailId != null && emailAddressOrHash != null)
                mailChimpManager.AutomationEmailQueues.GetAsync(workflowId, workflowEmailId, emailAddressOrHash);

            return View(result.Result);
        }

        public ActionResult GetAutomationEmailQueueResponse(string workflowId, string workflowEmailId)
        {
            Task<AutomationEmailQueueResponse> result = null;
            if (workflowId != null && workflowEmailId != null)
                mailChimpManager.AutomationEmailQueues.GetResponseAsync(workflowId, workflowEmailId);

            return View(result.Result);
        }
     
    }
}