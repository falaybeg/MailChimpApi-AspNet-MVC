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
    public class WebhooksApi
    {

        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public WebHook AddOrUpdateList(string listId, WebHook webhook)
        {
            Task<WebHook> result = null;

            if (listId != null && webhook != null)
                result = mailChimpManager.WebHooks.AddAsync(listId, webhook);

            return result.Result;
        }

        public void DeleteList(string listId, string webhookId)
        {
            if (listId != null && webhookId != null)
                mailChimpManager.WebHooks.DeleteAsync(listId, webhookId);
        }

        public IEnumerable<WebHook> GetAllWebhoks(string listId)
        {
            Task<IEnumerable<WebHook>> result = null;
            if(listId != null)
                result = mailChimpManager.WebHooks.GetAllAsync(listId);

            return result.Result;
        }

        public WebHookResponse GetList(string listId)
        {
            Task<WebHookResponse> result = null;
            if (listId != null)
                result = mailChimpManager.WebHooks.GetResponseAsync(listId);

            return result.Result;
        }

        public MergeField GetList(string listId, MergeField mergeField, int? mergeId = null)
        {
            Task<MergeField> result = null;

            if (listId != null && mergeField != null)
                result = mailChimpManager.WebHooks.UpdateAsync(listId, mergeField, mergeId);

            return result.Result;
        }

    }
}