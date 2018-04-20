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
    public class CampaignFolderController : Controller
    {
        /// <summary>
        ///  CampaignFolderController is to manage our CampaignFolders. Create a new folder, delete... 
        /// </summary>

        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddCampaignFolder(string folderName)
        {
            Task<Folder> result = null;
            if (folderName != null)
                result = mailChimpManager.CampaignFolders.AddAsync(folderName);

            return View(result.Result);
        }

        public ActionResult DeleteCampaignFolder(string folderId)
        {
            if (folderId != null)
                mailChimpManager.CampaignFolders.DeleteAsync(folderId);

            return View();
        }

        public ActionResult GetAllCampaignFolder(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Folder>> result = null;

            if (request != null)
                result = mailChimpManager.CampaignFolders.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetCampaignFolder(string folderId, BaseRequest request = null)
        {
            Task<Folder> result = null;
            if (folderId != null)
                result = mailChimpManager.CampaignFolders.GetAsync(folderId, request);

            return View(result.Result);
        }

        public ActionResult UpdateCampaignFolder(string folderId, string folderName)
        {
            Task<Folder> result = null;

            if (folderId != null && folderName != null)
                result = mailChimpManager.CampaignFolders.UpdateAsync(folderId, folderName);

            return View(result.Result);
        }

        public ActionResult GetCampaignFolderResponse(QueryableBaseRequest request = null)
        {
            Task<CampaignFolderResponse> result = null;

            if (request != null)
                result = mailChimpManager.CampaignFolders.GetResponseAsync(request);

            return View(result.Result);
        }

    }
}