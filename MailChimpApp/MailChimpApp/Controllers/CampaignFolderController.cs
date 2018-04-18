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
    public class CampaignFolderController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();


        public ActionResult GetAllCampaignFolder()
        {
            var result = mailChimpManager.CampaignFolders.GetAllAsync();
            return View(result.Result);
        }


        public ActionResult AddCampaignFolder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCampaignFolder(string folderName)
        {
            Task <Folder> result = null;

            if (folderName != null)
               result = mailChimpManager.CampaignFolders.AddAsync(folderName);

            return RedirectToAction("GetAllCampaignFolder", result.Result);
        }


        public ActionResult DeleteCampaignFolder(string folderId)
        {
            if (folderId != null)
                  mailChimpManager.CampaignFolders.DeleteAsync(folderId);

            return RedirectToAction("GetAllCampaignFolder");
        }

       

    }
}