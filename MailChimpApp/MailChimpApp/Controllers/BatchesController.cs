using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimpApp.ApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class BatchesController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddBatches(BatchRequest request = null)
        {
            Task<Batch> result = null;
            result = mailChimpManager.Batches.AddAsync(request);

            return View(result.Result);
        }

        public ActionResult DeleteBatches(string batchId)
        {
            if (batchId != null)
                mailChimpManager.Batches.DeleteAsync(batchId);
            return View();
        }

        public ActionResult GetAllBatches(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Batch>> result = null;
            result = mailChimpManager.Batches.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetBatchStatus(string batchId)
        {
            Task<Batch> result = null;

            if (batchId != null)
                result = mailChimpManager.Batches.GetBatchStatus(batchId);

            return View(result.Result);
        }

        public ActionResult GetBatchResponse(QueryableBaseRequest request = null)
        {
            Task<BatchResponse> result = null;
            result = mailChimpManager.Batches.GetResponseAsync(request);

            return View(result.Result);
        }
    }
}