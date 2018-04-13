using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpService.ApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MailChimpService.ApiServices
{
    public class AutomationEmailsApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public IEnumerable<Email> GetAllAutomationEmails(string workflowId)
        {
            Task<IEnumerable<Email>> result = null;
            if (workflowId != null)
                result = mailChimpManager.AutomationEmails.GetAllAsync(workflowId);

            return result.Result;
        }

        public Email GetAutomationEmail(string workflowId, string workflowEmailId)
        {
            Task<Email> result = null;
            if (workflowId != null && workflowEmailId != null)
                result = mailChimpManager.AutomationEmails.GetAsync(workflowId, workflowEmailId);

            return result.Result;
        }

        public AutomationEmailResponse GetAutomationEmail(string workflowId)
        {
            Task<AutomationEmailResponse> result = null;
            if (workflowId != null)
                result = mailChimpManager.AutomationEmails.GetResponseAsync(workflowId);

            return result.Result;
        }

        public void PauseAutomationEmails(string workflowId, string workflowEmailId)
        {
            if (workflowId != null && workflowEmailId != null)
                mailChimpManager.AutomationEmails.PauseAsync(workflowId, workflowId);
        }

        public void StartAutomationEmails(string workflowId, string workflowEmailId)
        {
            if (workflowId != null && workflowEmailId != null)
                mailChimpManager.AutomationEmails.StartAsync(workflowId, workflowEmailId);
        }

    }
}