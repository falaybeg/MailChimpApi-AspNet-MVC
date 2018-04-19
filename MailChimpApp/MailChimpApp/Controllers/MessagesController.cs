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
    public class MessagesController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddMessages(string conversationId, Message member)
        {
            if (conversationId != null)
                mailChimpManager.Messages.AddAsync(conversationId, member);

            return View();
        }

        public ActionResult GetAllMessages(string conversationId, MessageRequest request = null)
        {
            Task<IEnumerable<Message>> result = null; 
            if (conversationId != null)
                result = mailChimpManager.Messages.GetAllAsync(conversationId, request);

            return View(result.Result);
        }

        public ActionResult GetAllMessages(string conversationId, string messageId)
        {
            Task<Message> result = null;
            if (conversationId != null && messageId != null)
                result = mailChimpManager.Messages.GetAsync(conversationId, messageId);

            return View(result.Result);
        }
    }
}