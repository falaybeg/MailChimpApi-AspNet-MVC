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
    public class ClientsController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult GetAllClients(string listId, BaseRequest request = null)
        {
            Task<IEnumerable<Client>> result = null;
            if (listId != null)
                result = mailChimpManager.Clients.GetAllAsync(listId, request);

            return View(result.Result);
        }


        public ActionResult GetClientResponse(string listId, BaseRequest request = null)
        {
            Task<ClientResponse> result = null;

            if (listId != null)
                result = mailChimpManager.Clients.GetResponseAsync(listId);

            return View(result.Result);
        }

    }
}