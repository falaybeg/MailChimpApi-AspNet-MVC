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
    public class AutomationAPi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public IEnumerable<Automation> GetAllAutomation(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Automation>> result = null;
            mailChimpManager.Automations.GetAllAsync(request);
            return result.Result;
        }

        public Automation GetAutomation(string workflowId)
        {
            Task<Automation> result = null;
            if (workflowId != null)
                result = mailChimpManager.Automations.GetAsync(workflowId);

            return result.Result;
        }

        public AutomationResponse GetAutomationResponse(QueryableBaseRequest request = null)
        {
            Task<AutomationResponse> result = null;
            result = mailChimpManager.Automations.GetResponseAsync(request);

            return result.Result;
        }

        public void PauseAutomation(string workflowId)
        {
            if (workflowId != null)
                mailChimpManager.Automations.PauseAsync(workflowId);
        }
        public void StartAutomation(string workflowId)
        {
            if (workflowId != null)
                mailChimpManager.Automations.StartAsync(workflowId);
        }

    }
}