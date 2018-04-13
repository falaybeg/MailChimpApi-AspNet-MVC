using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MailChimpApp.ApiMailChimp
{
    public class AutomationEmailQueuesApi
    {

        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public Queue AddSubscriber(string workflowId, string workflowEmailId, string emailAddress)
        {
            Task<Queue> result = null;
            if (workflowId != null && workflowEmailId != null && emailAddress != null)
                mailChimpManager.AutomationEmailQueues.AddSubscriberAsync(workflowId, workflowEmailId, emailAddress);

                return result.Result;
        }


        public IEnumerable<Queue> GetAllAutomationEmailQueues(string workflowId, string workflowEmailId)
        {
            Task<IEnumerable<Queue>> result = null;
            if (workflowId != null && workflowEmailId != null)
                result = mailChimpManager.AutomationEmailQueues.GetAllAsync(workflowId, workflowEmailId);

            return result.Result;
        }

        public Queue GetAutomationEmailQueue(string workflowId, string workflowEmailId, string emailAddressOrHash)
        {
            Task<Queue> result = null;
            if (workflowId != null && workflowEmailId != null && emailAddressOrHash != null)
                mailChimpManager.AutomationEmailQueues.GetAsync(workflowId, workflowEmailId, emailAddressOrHash);

            return result.Result;
        }

        public AutomationEmailQueueResponse GetAutomationEmailQueueResponse(string workflowId, string workflowEmailId)
        {
            Task<AutomationEmailQueueResponse> result = null;
            if (workflowId != null && workflowEmailId != null)
                mailChimpManager.AutomationEmailQueues.GetResponseAsync(workflowId, workflowEmailId);

            return result.Result;
        }

    }
}