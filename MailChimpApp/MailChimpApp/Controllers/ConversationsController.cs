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
    public class ConversationsController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult GetAllConversation(ConversationRequest request)
        {
            Task<IEnumerable<Conversation>> result = null;
            result = mailChimpManager.Conversations.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetConversation(string conversationId)
        {
            Task<Conversation> result = null;

            if (conversationId != null)
                result = mailChimpManager.Conversations.GetAsync(conversationId);

            return View(result.Result);
        }

        public ActionResult GetConversationResponse(ConversationRequest request = null)
        {
            Task<ConversationResponse> result = null;
            result = mailChimpManager.Conversations.GetResponseAsync(request);

            return View(result.Result);
        }

    }
}