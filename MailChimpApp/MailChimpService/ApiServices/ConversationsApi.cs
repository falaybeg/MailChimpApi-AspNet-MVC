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
    public class ConversationsApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public IEnumerable<Conversation> GetAllConversation(ConversationRequest request)
        {
            Task<IEnumerable<Conversation>> result = null;
            result = mailChimpManager.Conversations.GetAllAsync(request);

            return result.Result;
        }

        public Conversation GetConversation(string conversationId)
        {
            Task<Conversation> result = null;

            if (conversationId != null)
                result = mailChimpManager.Conversations.GetAsync(conversationId);

            return result.Result;
        }

        public ConversationResponse GetConversationResponse(ConversationRequest request = null)
        {
            Task<ConversationResponse> result = null;
            result = mailChimpManager.Conversations.GetResponseAsync(request);

            return result.Result;
        }


    }
}