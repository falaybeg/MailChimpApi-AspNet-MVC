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
    public class ClientsApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public IEnumerable<Client> GetAllClients(string listId, BaseRequest request = null)
        {
            Task<IEnumerable<Client>> result = null;
            if(listId != null)
                result = mailChimpManager.Clients.GetAllAsync(listId, request);

            return result.Result;
        }


        public ClientResponse GetClientResponse(string listId, BaseRequest request = null)
        {
            Task<ClientResponse> result = null;

            if (listId != null)
                result = mailChimpManager.Clients.GetResponseAsync(listId);

            return result.Result;
        }


       
    }
}