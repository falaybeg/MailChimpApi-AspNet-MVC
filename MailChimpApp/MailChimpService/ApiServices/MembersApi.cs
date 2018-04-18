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
    public class MembersApi
    {

        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public void AddSubscribe(string listId, string subscribe)
        {
            if (subscribe != null)
            {
                // var listId = "c97e72b500";

                var member = new Member { EmailAddress = subscribe, StatusIfNew = Status.Subscribed };
                var result = this.mailChimpManager.Members.AddOrUpdateAsync(listId, member);
            }
        }

        public IEnumerable<Member> GetAllMember(string listId)
        {
            Task<IEnumerable<Member>> result = null;

            if(listId != null)
                result =  this.mailChimpManager.Members.GetAllAsync(listId);
            return result.Result;
        }

        public void  DeleteMember(string listId, string emailAddress)
        {
            if (listId != null && emailAddress != null)
            {
               this.mailChimpManager.Members.DeleteAsync(listId,emailAddress);
            }
        }

        public async Task<bool> ExistsMember(string listId, string emailAddress)
        {
           bool existsMember = false;
            if (listId != null && emailAddress != null)
            {
               existsMember = await this.mailChimpManager.Members.ExistsAsync(listId, emailAddress);
            }
            return existsMember;
        }
        //--------------

        public IEnumerable<Activity> GetMemberActivities(string listId, string emailAddress)
        {
            Task<IEnumerable<Activity>> result = null;
            if (listId != null && emailAddress != null)
            {
                result = this.mailChimpManager.Members.GetActivitiesAsync(listId, emailAddress);
            }

            return result.Result;
        }

        public Member GetMember(string listId, string emailAddress)
        {
            Task<Member> result = null;
            if (listId != null && emailAddress != null)
            {
                result = this.mailChimpManager.Members.GetAsync(listId, emailAddress);
            }

            return result.Result;
        }

        public MemberResponse GetResponse(string listId)
        {
            Task<MemberResponse> result = null;

            if (listId != null)
            { 
              result = this.mailChimpManager.Members.GetResponseAsync(listId);
            }
            return result.Result;
        }

        public int GetTotalItem(string listId, Status status)
        {
            Task<int> totalItem = null;

            if (listId != null)
            {
               totalItem = this.mailChimpManager.Members.GetTotalItems(listId, status);
            }

            return totalItem.Result;
        }

        public MemberSearchResult SearchMember(MemberSearchRequest request)
        {
            Task<MemberSearchResult> result = null;
            if (request != null)
            {
               result = this.mailChimpManager.Members.SearchAsync(request);
            }

            return result.Result;
        }

    }
}