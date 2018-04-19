using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.ApiManager;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class GrowthHistoriesController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult GetAllGrowthHistory(string listId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<History>> result = null;

            if (listId != null)
                result = mailChimpManager.GrowthHistories.GetAllAsync(listId, request);

            return View(result.Result);
        }

        public ActionResult GetHistory(string listId, string month, BaseRequest request = null)
        {
            Task<History> result = null;

            if (listId != null && month != null)
                result = mailChimpManager.GrowthHistories.GetAsync(listId, month, request);

            return View(result.Result);
        }

        public ActionResult GetGrowthHistoryResponse(string listId, QueryableBaseRequest request = null)
        {
            Task<GrowthHistoryResponse> result = null;

            if (listId != null)
                result = mailChimpManager.GrowthHistories.GetResponseAsync(listId, request);

            return View(result.Result);
        }
    }
}