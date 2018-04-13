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
    public class BatchesApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public Batch AddBatches(BatchRequest request = null)
        {
            Task<Batch> result = null;
            result = mailChimpManager.Batches.AddAsync(request);

            return result.Result;
        }

        public void DeleteBatches(string batchId)
        {
            if (batchId != null)
                mailChimpManager.Batches.DeleteAsync(batchId);
        }

        public IEnumerable<Batch> GetAllBatches(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Batch>> result = null;
            result = mailChimpManager.Batches.GetAllAsync(request);

            return result.Result;
        }

        public Batch GetBatchStatus(string batchId)
        { 
            Task<Batch> result = null;

            if (batchId != null)
                result = mailChimpManager.Batches.GetBatchStatus(batchId);

            return result.Result;
        }

        public BatchResponse GetBatchResponse(QueryableBaseRequest request = null)
        {
            Task<BatchResponse> result = null;
            result = mailChimpManager.Batches.GetResponseAsync(request);

            return result.Result;
        }

    }
}