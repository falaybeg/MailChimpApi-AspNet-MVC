using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailChimpApp.ApiMailChimp
{
    public class MembersApi
    {

        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public void AddSubscribe(string listId, string subscribe)
        {

            // var mailChimpListCollection = await this.mailChimpManager.Lists.GetAllAsync().ConfigureAwait(false);

            if (subscribe != null)
            {
                // var listId = "c97e72b500";
                var member = new Member { EmailAddress = subscribe, StatusIfNew = Status.Subscribed };
                var result = this.mailChimpManager.Members.AddOrUpdateAsync(listId, member);
            }


        }
    }
}