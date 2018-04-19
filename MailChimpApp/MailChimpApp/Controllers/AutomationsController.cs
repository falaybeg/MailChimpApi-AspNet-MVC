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
    public class AutomationsController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult GetAllAutomation(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Automation>> result = null;
            mailChimpManager.Automations.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetAutomation(string workflowId)
        {
            Task<Automation> result = null;
            if (workflowId != null)
                result = mailChimpManager.Automations.GetAsync(workflowId);

            return View(result.Result);
        }


        public ActionResult PauseAutomation(string workflowId)
        {
            if (workflowId != null)
                mailChimpManager.Automations.PauseAsync(workflowId);

            return View();
        }

        public ActionResult StartAutomation(string workflowId)
        {
            if (workflowId != null)
                mailChimpManager.Automations.StartAsync(workflowId);

            return View();
        }
   
        public ActionResult GetAutomationResponse(QueryableBaseRequest request = null)
        {
            Task<AutomationResponse> result = null;
            result = mailChimpManager.Automations.GetResponseAsync(request);

            return View(result.Result);
        }
    
    }
}