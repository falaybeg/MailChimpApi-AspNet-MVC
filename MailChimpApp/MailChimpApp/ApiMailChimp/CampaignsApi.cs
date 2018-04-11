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
    public class CampaignsApi
    {

        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public Campaign AddCampaign(Campaign campaign)
        {
            Task<Campaign> result = null;
            if(campaign != null)
                result = mailChimpManager.Campaigns.AddAsync(campaign);

            return result.Result;
        }

        [Obsolete]
        public Campaign AddOrUpdateCampaign(string campaignId, Campaign campaign)
        {
            Task<Campaign> result = null;
            if (campaign != null)
                 result = mailChimpManager.Campaigns.AddOrUpdateAsync(campaignId, campaign);

            return result.Result;
        }

        public Campaign AddOrUpdateCampaign(Campaign campaign)
        {
            Task<Campaign> result = null;
            if (campaign != null)
                result = mailChimpManager.Campaigns.AddOrUpdateAsync(campaign);

            return result.Result;
        }

        public void CancelCampaign(string campaignId)
        {
            mailChimpManager.Campaigns.CancelAsync(campaignId);
        }

        public void DeleteCampaign(string campaignId)
        {
            mailChimpManager.Campaigns.DeleteAsync(campaignId);
        }

        public void ExecuteCampaignAction(string campaignId, CampaignAction campaignAction)
        {
            if (campaignId != null)
                mailChimpManager.Campaigns.ExecuteCampaignActionAsync(campaignId, campaignAction);
        }

        public IEnumerable<Campaign> GetAllCampaigns(CampaignRequest request = null)
        {
            Task<IEnumerable<Campaign>> result = null;
            if (request != null)
                result = mailChimpManager.Campaigns.GetAll(request);

            return result.Result;
        }

        public Campaign GetCampaign(string campaignId)
        {
            Task<Campaign> result = null;

            if (campaignId != null)
                result = mailChimpManager.Campaigns.GetAsync(campaignId);

            return result.Result;
        }

        public CampaignResponse GetCampaign(CampaignRequest request = null)
        {
            Task<CampaignResponse> result = null;

            if (request != null)
                result = mailChimpManager.Campaigns.GetResponseAsync(request);

            return result.Result;
        }

        public ReplicateResponse ReplicateCampaign(string campaignId)
        {
            Task<ReplicateResponse> result = null;

            if (campaignId != null)
                result = mailChimpManager.Campaigns.ReplicateCampaignAsync(campaignId);

            return result.Result;
        }

        public void ScheduleCampaign(string campaignId, CampaignScheduleRequest content = null)
        {
            if (campaignId != null && content != null)
                 mailChimpManager.Campaigns.ScheduleAsync(campaignId, content);
        }

        public void SendCampaign(string campaignId)
        {
            mailChimpManager.Campaigns.SendAsync(campaignId);
        }

        public SendChecklistResponse SendCheckList(string id)
        {
            Task<SendChecklistResponse> result = null;

            if (id != null)
                result = mailChimpManager.Campaigns.SendChecklistAsync(id);

            return result.Result;
        }

        public void TestCampaign(string campaignId, CampaignTestRequest content = null)
        {
            if(campaignId != null && content != null)
                mailChimpManager.Campaigns.TestAsync(campaignId, content);

        }

        public Campaign UpdateCampaign(string campaignId, Campaign campaign)
        {
            Task<Campaign> result = null;

            if (campaignId != null && campaign != null)
                result = mailChimpManager.Campaigns.UpdateAsync(campaignId, campaign);

            return result.Result;
        }

    }
}