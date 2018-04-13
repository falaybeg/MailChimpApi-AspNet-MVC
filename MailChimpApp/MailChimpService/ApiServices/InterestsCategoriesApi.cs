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
    public class InterestsCategoriesApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public InterestCategory AddOrUpdateCategory(InterestCategory category, string listId)
        {
            Task<InterestCategory> result = null;

            if (category != null && listId != null)
                result = mailChimpManager.InterestCategories.AddOrUpdateAsync(category, listId);

            return result.Result;
        }

        public void DeleteList(string listId, string categoryId)
        {
            if (listId != null && categoryId != null)
                mailChimpManager.InterestCategories.DeleteAsync(listId, categoryId);
        }

        public IEnumerable<InterestCategory> GetAllCategories(string listId, InterestCategoryRequest request = null)
        {
            Task<IEnumerable<InterestCategory>> result = null;
            if(listId != null)
                result = mailChimpManager.InterestCategories.GetAllAsync(listId, request);

            return result.Result;
        }
        public InterestCategory GetCategory(string listId, string categoryId)
        {
            Task<InterestCategory> result = null;

            if (listId != null && categoryId != null)
                result = mailChimpManager.InterestCategories.GetAsync(listId, categoryId);

            return result.Result;
        }

        public InterestCategoryResponse GetCategoryResponse(string listId, InterestCategoryRequest request = null)
        {
            Task<InterestCategoryResponse> result = null;

            if (listId != null)
                result = mailChimpManager.InterestCategories.GetResponseAsync(listId, request);

            return result.Result;
        }

    }
}