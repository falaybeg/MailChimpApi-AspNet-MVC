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
    public class ListsApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public List AddOrUpdateList(List list)
        {
            Task<List> result = null;

            if(list != null)
                result = mailChimpManager.Lists.AddOrUpdateAsync(list);

            return result.Result;
        }

        public void DeleteList(string listId)
        {
            if(listId != null)
            mailChimpManager.Lists.DeleteAsync(listId);
        }

        public IEnumerable<List> GetAllLists(ListRequest request = null)
        {
            Task<IEnumerable<List>> result = null;
                result = mailChimpManager.Lists.GetAllAsync(request);

            return result.Result;
        }


        public List GetList(string listId)
        {
            Task<List> result = null;
            if (listId != null)

                result = mailChimpManager.Lists.GetAsync(listId);

            return result.Result;
        }

        public ListResponse GetListResponse(ListRequest request = null)
        {
            Task<ListResponse> result = null;
            result = mailChimpManager.Lists.GetResponseAsync(request);

            return result.Result;
        }

    }
}