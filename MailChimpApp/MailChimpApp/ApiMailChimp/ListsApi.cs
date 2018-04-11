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
    public class ListsApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public List AddOrUpdateList(List list)
        {
            Task<List> listResult = null;

            if(list != null)
                listResult = mailChimpManager.Lists.AddOrUpdateAsync(list);

            return listResult.Result;
        }

        public void DeleteList(string listId)
        {
            if(listId != null)
            mailChimpManager.Lists.DeleteAsync(listId);
        }

        public IEnumerable<List> GetAllLists(ListRequest request = null)
        {
            Task<IEnumerable<List>> listResult = null;
                listResult = mailChimpManager.Lists.GetAllAsync(request);

            return listResult.Result;
        }


        public List GetList(string listId)
        {
            Task<List> listResult = null;
            listResult = mailChimpManager.Lists.GetAsync(listId);

            return listResult.Result;
        }

        public ListResponse GetListResponse(ListRequest request = null)
        {
            Task<ListResponse> listResult = null;
            listResult = mailChimpManager.Lists.GetResponseAsync(request);

            return listResult.Result;
        }

    }
}