using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.ApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class ReportController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();


        public ActionResult GetAllReports()
        {
            Task<IEnumerable<Report>> result = null;
            result = mailChimpManager.Reports.GetAllReportsAsync();

            return View(result.Result);
        }


        public ActionResult GetReport(string campaignId)
        {
            Task<Report> result = null;
            result = mailChimpManager.Reports.GetReportAsync(campaignId);

            return View(result.Result);
        }

        public ActionResult GetAbuseReports(string campaignId, string reportId, BaseRequest request = null)
        {
            Task<AbuseReport> result = null;

            if (campaignId != null && reportId != null)
                result = mailChimpManager.Reports.GetAbuseReportAsync(campaignId, reportId);

            return View(result.Result);
        }

        public ActionResult GetAbuseReports(string campaignId, BaseRequest request = null)
        {
            Task<AbuseReportResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetAbuseReportsAsync(campaignId);

            return View(result.Result);
        }

        public ActionResult GetCampaignAdvice(string campaignId, BaseRequest request = null)
        {
            Task<IEnumerable<Advice>> result = null;
            result = mailChimpManager.Reports.GetCampaignAdviceAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetCampaignAdvice(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<UrlClicked>> result = null;
            result = mailChimpManager.Reports.GetClickReportAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetClickReportDetails(string campaignId, string linkId, BaseRequest request = null)
        {
            Task<UrlClicked> result = null;

            if (campaignId != null && linkId != null)
                result = mailChimpManager.Reports.GetClickReportDetailsAsync(campaignId, linkId, request);

            return View(result.Result);
        }

        public ActionResult GetClickReportMember(string campaignId, string linkId, string emailAddressOrHash, BaseRequest request = null)
        {
            Task<ClickMember> result = null;

            if (campaignId != null && linkId != null && emailAddressOrHash != null)
                result = mailChimpManager.Reports.GetClickReportMemberAsync(campaignId, linkId, emailAddressOrHash, request);

            return View(result.Result);
        }

        public ActionResult GetClickReportMembers(string campaignId, string linkId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<ClickMember>> result = null;

            if (campaignId != null && linkId != null)
                result = mailChimpManager.Reports.GetClickReportMembersAsync(campaignId, linkId, request);

            return View(result.Result);
        }


        public ActionResult GetDomainPerformanceReport(string campaignId, BaseRequest request = null)
        {
            Task<IEnumerable<Domain>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetDomainPerformanceAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetEepUrlReport(string campaignId, BaseRequest request = null)
        {
            Task<EepUrlActivity> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetEepUrlReportAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetEmailActivitiesReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<EmailActivity>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetEmailActivitiesAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetEepUrlReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<EmailResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetEmailActivitiesResponseAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetEmailActivityReport(string campaignId, string emailAddressOrHash, BaseRequest request = null)
        {
            Task<EmailActivity> result = null;

            if (campaignId != null && emailAddressOrHash != null)
                result = mailChimpManager.Reports.GetEmailActivityAsync(campaignId, emailAddressOrHash, request);

            return View(result.Result);
        }

        public ActionResult GetLocationReport(string campaignId, BaseRequest request = null)
        {
            Task<IEnumerable<OpenLocation>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetLocationsAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetResponseReport(ReportRequest request = null)
        {
            Task<ReportResponse> result = null;
            result = mailChimpManager.Reports.GetResponseAsync(request);

            return View(result.Result);
        }

        public ActionResult GetSentToRecipientReport(string campaignId, string emailAddressOrHash, QueryableBaseRequest request = null)
        {
            Task<SentTo> result = null;

            if (campaignId != null && emailAddressOrHash != null)
                result = mailChimpManager.Reports.GetSentToRecipientAsync(campaignId, emailAddressOrHash, request);

            return View(result.Result);
        }


        public ActionResult GetSentToRecipientsReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<SentTo>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetSentToRecipientsAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetSentToRecipientResponse(string campaignId, QueryableBaseRequest request = null)
        {
            Task<SentToResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetSentToRecipientsResponseAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetSubReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Report>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetSubReportAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetUnsubscriberReport(string campaignId, string emailAddessOrHash, BaseRequest request = null)
        {
            Task<Unsubscribe> result = null;

            if (campaignId != null && emailAddessOrHash != null)
                result = mailChimpManager.Reports.GetUnsubscriberAsync(campaignId, emailAddessOrHash, request);

            return View(result.Result);
        }

        public ActionResult GetUnsubscribesReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Unsubscribe>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetUnsubscribesAsync(campaignId, request);

            return View(result.Result);
        }
    }
}