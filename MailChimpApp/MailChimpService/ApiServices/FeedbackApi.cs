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
    public class FeedbackApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public Feedback AddOrUpdateFeedback(string campaignId, Feedback feedback)
        {
            Task<Feedback> result = null;

            if (campaignId != null && feedback != null)
                result = mailChimpManager.Feedback.AddOrUpdateAsync(campaignId, feedback);

            return result.Result;
        }

        public void DeleteFeedback(string campaignId, string feedbackId)
        {
            if (campaignId != null && feedbackId != null)
                mailChimpManager.Feedback.DeleteAsync(campaignId, feedbackId);
        }

        public IEnumerable<Feedback> GetAllLists(string campaignId, FeedbackRequest request = null)
        {
            Task<IEnumerable<Feedback>> result = null;

            if(campaignId != null && request != null)
                result = mailChimpManager.Feedback.GetAllAsync(campaignId, request);

            return result.Result;
        }

        public Feedback GetFeedback(string campaignId, string feedbackId)
        {
            Task<Feedback> result = null;

            if (campaignId != null && feedbackId != null)
                result = mailChimpManager.Feedback.GetAsync(campaignId, feedbackId);

            return result.Result;
        }

        public FeedBackResponse GetFeedbackResponse(string campaignId, FeedbackRequest request = null)
        {
            Task<FeedBackResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Feedback.GetResponseAsync(campaignId, request);

            return result.Result;
        }

    }
}