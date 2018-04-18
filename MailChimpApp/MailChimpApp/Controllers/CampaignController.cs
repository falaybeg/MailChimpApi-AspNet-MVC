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
    public class CampaignController : Controller
    {
        IMailChimpManager campaign = MailChimApiManager.MailChimpService();


        public ActionResult AddCampaign(Campaign camp)
        {
            

            return View();
        }

        public ActionResult DeleteCampaign(string campaignId)
        {
            if (campaignId != null)
                campaign.Campaigns.DeleteAsync(campaignId);

            return RedirectToAction("GetAllCampaigns");
        }

        public ActionResult GetAllCampaigns()
        {
            Task<IEnumerable<Campaign>> result = null;
            result = campaign.Campaigns.GetAll();

            return View(result.Result);
        }

        public ActionResult GetCampaign(string campaignId)
        {
            Task<Campaign> result = null;

            if (campaignId != null)
                result = campaign.Campaigns.GetAsync(campaignId);

            return View(result.Result);
        }

        public void ScheduleCampaign(string campaignId, CampaignScheduleRequest content = null)
        {
            if (campaignId != null && content != null)
                campaign.Campaigns.ScheduleAsync(campaignId, content);
        }

        public void SendCampaign(string campaignId)
        {
            campaign.Campaigns.SendAsync(campaignId);
        }

        public ActionResult UpdateCampaign(string campaignId, Campaign campaignModel)
        {
            Task<Campaign> result = null;

            if (campaignId != null && campaign != null)
                result = campaign.Campaigns.UpdateAsync(campaignId, campaignModel);

            return View(result.Result);
        }
    }
}