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
    public class GrowthHistoryApi
    {

        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public IEnumerable<History> GetAllGrowthHistory(string listId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<History>> result = null;

            if(listId != null)
                result = mailChimpManager.GrowthHistories.GetAllAsync(listId, request);

            return result.Result;
        }


        public History GetHistory(string listId, string month, BaseRequest request = null)
        {
            Task<History> result = null;

            if (listId != null && month != null)
                result = mailChimpManager.GrowthHistories.GetAsync(listId, month, request);

            return result.Result;
        }

        public GrowthHistoryResponse GetGrowthHistoryResponse(string listId, QueryableBaseRequest request = null)
        {
            Task<GrowthHistoryResponse> result = null;

            if(listId != null)
                result = mailChimpManager.GrowthHistories.GetResponseAsync(listId, request);

            return result.Result;
        }
    }
}