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
    public class AutomationEmailsController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult GetAllAutomationEmails(string workflowId)
        {
            Task<IEnumerable<Email>> result = null;
            if (workflowId != null)
                result = mailChimpManager.AutomationEmails.GetAllAsync(workflowId);

            return View(result.Result);
        }

        public ActionResult GetAutomationEmail(string workflowId, string workflowEmailId)
        {
            Task<Email> result = null;
            if (workflowId != null && workflowEmailId != null)
                result = mailChimpManager.AutomationEmails.GetAsync(workflowId, workflowEmailId);

            return View(result.Result);
        }

        public ActionResult GetAutomationEmail(string workflowId)
        {
            Task<AutomationEmailResponse> result = null;
            if (workflowId != null)
                result = mailChimpManager.AutomationEmails.GetResponseAsync(workflowId);

            return View(result.Result);
        }

        public ActionResult PauseAutomationEmails(string workflowId, string workflowEmailId)
        {
            if (workflowId != null && workflowEmailId != null)
                mailChimpManager.AutomationEmails.PauseAsync(workflowId, workflowId);

            return View();
        }

        public ActionResult StartAutomationEmails(string workflowId, string workflowEmailId)
        {
            if (workflowId != null && workflowEmailId != null)
                mailChimpManager.AutomationEmails.StartAsync(workflowId, workflowEmailId);

            return View();
        }
    }
}