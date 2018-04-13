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
    public class ReportsApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public AbuseReport GetAbuseReports(string campaignId, string reportId, BaseRequest request = null)
        {
            Task<AbuseReport> result = null;

            if (campaignId != null && reportId != null)
                result = mailChimpManager.Reports.GetAbuseReportAsync(campaignId, reportId);

            return result.Result;
        }

        public AbuseReportResponse GetAbuseReports(string campaignId, BaseRequest request = null)
        {
            Task<AbuseReportResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetAbuseReportsAsync(campaignId);

            return result.Result;
        }

        public IEnumerable<Report> GetAllReports(ReportRequest request = null)
        {
            Task<IEnumerable<Report>> result = null;
            result = mailChimpManager.Reports.GetAllReportsAsync(request);

            return result.Result;
        }

        public IEnumerable<Advice> GetCampaignAdvice(string campaignId, BaseRequest request = null)
        {
            Task<IEnumerable<Advice>> result = null;
            result = mailChimpManager.Reports.GetCampaignAdviceAsync(campaignId, request);

            return result.Result;
        }
        public IEnumerable<UrlClicked> GetCampaignAdvice(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<UrlClicked>> result = null;
            result = mailChimpManager.Reports.GetClickReportAsync(campaignId, request);

            return result.Result;
        }

        public UrlClicked GetClickReportDetails(string campaignId, string linkId ,BaseRequest request = null)
        {
            Task<UrlClicked> result = null;

            if (campaignId != null && linkId != null)
                result = mailChimpManager.Reports.GetClickReportDetailsAsync(campaignId, linkId, request);

            return result.Result;
        }

        public ClickMember GetClickReportMember(string campaignId, string linkId, string emailAddressOrHash, BaseRequest request = null)
        {
            Task<ClickMember> result = null;

            if (campaignId != null && linkId != null && emailAddressOrHash != null)
                result = mailChimpManager.Reports.GetClickReportMemberAsync(campaignId, linkId, emailAddressOrHash ,request);

            return result.Result;
        }

        public IEnumerable<ClickMember> GetClickReportMembers(string campaignId, string linkId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<ClickMember>> result = null;

            if (campaignId != null && linkId != null)
                result = mailChimpManager.Reports.GetClickReportMembersAsync(campaignId, linkId, request);

            return result.Result;
        }


        public IEnumerable<Domain> GetDomainPerformanceReport(string campaignId,  BaseRequest request = null)
        {
            Task<IEnumerable<Domain>> result = null;

            if (campaignId != null )
                result = mailChimpManager.Reports.GetDomainPerformanceAsync(campaignId, request);

            return result.Result;
        }

        public EepUrlActivity GetEepUrlReport(string campaignId, BaseRequest request = null)
        {
            Task<EepUrlActivity> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetEepUrlReportAsync(campaignId, request);

            return result.Result;
        }

        public IEnumerable<EmailActivity> GetEmailActivitiesReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<EmailActivity>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetEmailActivitiesAsync(campaignId, request);

            return result.Result;
        }

        public EmailResponse GetEepUrlReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<EmailResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetEmailActivitiesResponseAsync(campaignId, request);

            return result.Result;
        }

        public EmailActivity GetEmailActivityReport(string campaignId, string emailAddressOrHash, BaseRequest request = null)
        {
            Task<EmailActivity> result = null;

            if (campaignId != null && emailAddressOrHash != null)
                result = mailChimpManager.Reports.GetEmailActivityAsync(campaignId, emailAddressOrHash, request);

            return result.Result;
        }

        public IEnumerable<OpenLocation> GetLocationReport(string campaignId, BaseRequest request = null)
        {
            Task<IEnumerable<OpenLocation>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetLocationsAsync(campaignId, request);

            return result.Result;
        }

        public Report GetAllReports(string campaignId, BaseRequest request = null)
        {
            Task<Report> result = null;
            result = mailChimpManager.Reports.GetReportAsync(campaignId, request);

            return result.Result;
        }

        public ReportResponse GetResponseReport(ReportRequest request = null)
        {
            Task<ReportResponse> result = null;
            result = mailChimpManager.Reports.GetResponseAsync(request);

            return result.Result;
        }

        public SentTo GetSentToRecipientReport(string campaignId, string emailAddressOrHash, QueryableBaseRequest request = null)
        {
            Task<SentTo> result = null;

            if (campaignId != null && emailAddressOrHash != null)
                result = mailChimpManager.Reports.GetSentToRecipientAsync(campaignId, emailAddressOrHash, request);

            return result.Result;
        }


        public IEnumerable<SentTo> GetSentToRecipientsReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<SentTo>> result = null;

            if (campaignId != null)
                result =  mailChimpManager.Reports.GetSentToRecipientsAsync(campaignId, request);

            return result.Result;
        }

        public SentToResponse GetSentToRecipientResponse(string campaignId, QueryableBaseRequest request = null)
        {
            Task<SentToResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetSentToRecipientsResponseAsync(campaignId, request);

            return result.Result;
        }

        public IEnumerable<Report> GetSubReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Report>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetSubReportAsync(campaignId, request);

            return result.Result;
        }

        public Unsubscribe GetUnsubscriberReport(string campaignId, string emailAddessOrHash, BaseRequest request = null)
        {
            Task<Unsubscribe> result = null;

            if (campaignId != null && emailAddessOrHash != null)
                result = mailChimpManager.Reports.GetUnsubscriberAsync(campaignId, emailAddessOrHash ,request);

            return result.Result;
        }

        public IEnumerable<Unsubscribe> GetUnsubscribesReport(string campaignId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Unsubscribe>> result = null;

            if (campaignId != null)
                result = mailChimpManager.Reports.GetUnsubscribesAsync(campaignId, request);

            return result.Result;
        }

    }
}