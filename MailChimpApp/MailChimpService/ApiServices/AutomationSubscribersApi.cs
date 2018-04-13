using MailChimp.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MailChimp.Net.Models;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimpService.ApiManager;

namespace MailChimpService.ApiServices
{ 
    public class AutomationSubscribersApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public IEnumerable<Subscriber> GetRemovedSubsribers(string workflowId)
        {
            Task<IEnumerable<Subscriber>> result = null;

            if (workflowId != null)
                result = mailChimpManager.AutomationSubscribers.GetRemovedSubscribersAsync(workflowId);

            return result.Result;
        }
        public AutomationSubscriberResponse GetRemovedSubsribersResponse(string workflowId)
        {
            Task<AutomationSubscriberResponse> result = null;

            if (workflowId != null)
                result = mailChimpManager.AutomationSubscribers.GetRemovedSubscribersResponseAsync(workflowId);

            return result.Result;
        }

        public Subscriber RemoveAutomationSubscriber(string workflowId, string emailAddress)
        {
            Task<Subscriber> result = null;

            if (workflowId != null && emailAddress != null)
                result = mailChimpManager.AutomationSubscribers.RemoveSubscriberAsync(workflowId, emailAddress);

            return result.Result;
        }

    }
}