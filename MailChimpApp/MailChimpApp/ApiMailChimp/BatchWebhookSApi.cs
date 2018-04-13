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
    public class BatchWebhooksApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public BatchWebHook AddBatchWebhook(string url)
        {
            Task<BatchWebHook> result = null;

            if (url != null)
                result = mailChimpManager.BatchWebHooks.AddAsync(url);

            return result.Result;
        }

        public void DeleteList(string batchWebHookId)
        {
            if (batchWebHookId != null)
                mailChimpManager.BatchWebHooks.DeleteAsync(batchWebHookId);
        }

        public IEnumerable<BatchWebHook> GetAllBatchWebhooks(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<BatchWebHook>> result = null;
            result = mailChimpManager.BatchWebHooks.GetAllAsync(request);

            return result.Result;
        }

        public BatchWebHookResponse GetBatchWebhookResponse(QueryableBaseRequest request = null)
        {
            Task<BatchWebHookResponse> result = null;
            result = mailChimpManager.BatchWebHooks.GetResponseAsync(request);

            return result.Result;
        }


        public BatchWebHook UpdateBatchWebhook(string batchWebHookId, string url)
        {
            Task<BatchWebHook> result = null;

            if (batchWebHookId != null && url != null)
                result = mailChimpManager.BatchWebHooks.UpdateAsync(batchWebHookId, url);

            return result.Result;
        }


    }
}