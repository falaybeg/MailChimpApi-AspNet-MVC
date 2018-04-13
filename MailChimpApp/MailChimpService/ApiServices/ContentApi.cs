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
    public class ContentApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public Content AddOrUpdateContent(string campaignId, ContentRequest request = null)
        {
            Task<Content> result = null;
            if (campaignId != null)
                result = mailChimpManager.Content.AddOrUpdateAsync(campaignId, request);

            return result.Result;
        }


        public Content GetContent(string campaignId)
        {
            Task<Content> result = null;
            if (campaignId != null)
                result = mailChimpManager.Content.GetAsync(campaignId);

            return result.Result;
        }
    }
}