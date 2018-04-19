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
    public class FeedbackController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddOrUpdateFeedback(string campaignId, Feedback feedback)
        {
            Task<Feedback> result = null;

            if (campaignId != null && feedback != null)
                result = mailChimpManager.Feedback.AddOrUpdateAsync(campaignId, feedback);

            return View(result.Result);
        }

        public ActionResult DeleteFeedback(string campaignId, string feedbackId)
        {
            if (campaignId != null && feedbackId != null)
                mailChimpManager.Feedback.DeleteAsync(campaignId, feedbackId);

            return View();
        }

        public ActionResult GetAllLists(string campaignId, FeedbackRequest request = null)
        {
            Task<IEnumerable<Feedback>> result = null;

            if (campaignId != null && request != null)
                result = mailChimpManager.Feedback.GetAllAsync(campaignId, request);

            return View(result.Result);
        }

        public ActionResult GetFeedback(string campaignId, string feedbackId)
        {
            Task<Feedback> result = null;

            if (campaignId != null && feedbackId != null)
                result = mailChimpManager.Feedback.GetAsync(campaignId, feedbackId);

            return View(result.Result);
        }

        public ActionResult GetFeedbackResponse(string campaignId, FeedbackRequest request = null)
        {
            Task<FeedBackResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Feedback.GetResponseAsync(campaignId, request);

            return View(result.Result);
        }

    }
}