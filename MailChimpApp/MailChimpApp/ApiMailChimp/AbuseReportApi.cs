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
    public class AbuseReportApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public IEnumerable<AbuseReport> GetAllAbuseReports(string listId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<AbuseReport>> result = null;
            if (listId != null)
                result = mailChimpManager.AbuseReports.GetAllAsync(listId, request);

            return result.Result;
        }
        
        public AbuseReport GetAbuseReport(string listId, string reportId, QueryableBaseRequest request = null)
        {
            Task<AbuseReport> result = null;
            if (listId != null && reportId != null)
                result = mailChimpManager.AbuseReports.GetAsync(listId, reportId, request);

            return result.Result;
        }

        public AbuseReportResponse GetAbuseReportResponse(string listId, QueryableBaseRequest request = null)
        {
            Task<AbuseReportResponse> result = null;
            if (listId != null)
                result = mailChimpManager.AbuseReports.GetResponseAsync(listId, request);

            return result.Result;
        }

    }
}