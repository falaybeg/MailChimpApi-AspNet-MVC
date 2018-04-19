using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.ApiManager;
using MailChimpApp.Models;
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
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();


        public ActionResult AddCampaign( )
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddCampaign(Campaign campaign)
        {
            if (campaign != null)
            {
                campaign.Type = CampaignType.Regular;
                mailChimpManager.Campaigns.AddAsync(campaign);
                return RedirectToAction("GetAllCampaigns");
            }
            return View();
        }

        public ActionResult DeleteCampaign(string campaignId)
        {
            if (campaignId != null)
                mailChimpManager.Campaigns.DeleteAsync(campaignId);

            return RedirectToAction("GetAllCampaigns");
        }

        public ActionResult GetAllCampaigns()
        {
            Task<IEnumerable<Campaign>> result = null;
            result = mailChimpManager.Campaigns.GetAll();

            return View(result.Result);
        }

        public ActionResult GetCampaign(string campaignId)
        {
            Task<Campaign> result = null;

            if (campaignId != null)
                result = mailChimpManager.Campaigns.GetAsync(campaignId);

            return View(result.Result);
        }

        public ActionResult TestCampaign(string campaignId, string[] email)
        {
            MemberModel message = null;
            if (campaignId != null && email != null)
            {
                CampaignTestRequest content = new CampaignTestRequest
                {
                    Emails = email,
                    EmailType = "html"
                };
                mailChimpManager.Campaigns.TestAsync(campaignId, content);
                message = new MemberModel
                {
                    TextMessage = "Test Email has been sent !"
                }; 

            }

            return View(message);
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

        public ActionResult UpdateCampaign(string campaignId, Campaign campaignModel)
        {
            Task<Campaign> result = null;

            if (campaignId != null && campaignModel != null)
                result = mailChimpManager.Campaigns.UpdateAsync(campaignId, campaignModel);

            return View(result.Result);
        }
    }
}