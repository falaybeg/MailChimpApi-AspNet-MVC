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
    public class InterestsApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public Interest AddOrUpdateInterest(Interest list)
        {
            Task<Interest> result = null;

            if (list != null)
                result = mailChimpManager.Interests.AddOrUpdateAsync(list);

            return result.Result;
        }

        public void DeleteInterest(string listId, string interestCategoryId, string interestId)
        {
            if (listId != null && interestCategoryId != null && interestId != null)
                mailChimpManager.Interests.DeleteAsync(listId, interestCategoryId, interestId);
        }

        public IEnumerable<Interest> GetAllInterest(string listId, string interestCategoryId, QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Interest>> result = null;

            if (listId != null && interestCategoryId != null)
                result = mailChimpManager.Interests.GetAllAsync(listId, interestCategoryId, request);

            return result.Result;
        }
        public Interest GetInterest(string listId, string interestCategoryId, string interestId, BaseRequest request = null)
        {
            Task<Interest> result = null;

            if (listId != null && interestCategoryId != null && interestId != null)
                result = mailChimpManager.Interests.GetAsync(listId, interestCategoryId, interestId, request);

            return result.Result;
        }

        public InterestResponse GetInterestResponse(string listId, string interestCategoryId, InterestCategoryRequest request = null)
        {
            Task<InterestResponse> result = null;

            if (listId != null && interestCategoryId != null)
                result = mailChimpManager.Interests.GetResponseAsync(listId, interestCategoryId, request);

            return result.Result;
        }

        public Interest UpdateInterest(Interest list)
        {
            Task<Interest> result = null;

            if (list != null)
                result = mailChimpManager.Interests.UpdateAsync(list);

            return result.Result;
        }
    }
}