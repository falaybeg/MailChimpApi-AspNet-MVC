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
        /// <summary>
        /// CampaignController is to manage our Campaigns. We can create, delete, get all campaigns.. etc 
        /// </summary>

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

        /// <summary>
        /// Schedule Campaign (Set campaign sending time)
        /// </summary>
        /// <param name="campaignId">campaignId is to choose specific campaign which we want to send</param>
        /// <param name="content">It is to set our campaign sending time </param>
        public void ScheduleCampaign(string campaignId, CampaignScheduleRequest content = null)
        {
            if (campaignId != null && content != null)
                mailChimpManager.Campaigns.ScheduleAsync(campaignId, content);
        }

        /// <summary>
        /// Send a specific Campaign to users by specific campaignId
        /// </summary>
        /// <param name="campaignId"></param>
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