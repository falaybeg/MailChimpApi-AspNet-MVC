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
    public class TemplateFolderController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddTemplateFolder(string folderName)
        {
            Task<Folder> result = null;
            if (folderName != null)
                result = mailChimpManager.TemplateFolders.AddAsync(folderName);

            return View(result.Result);
        }

        public ActionResult DeleteTemplateFolder(string folderId)
        {
            if (folderId != null)
                mailChimpManager.TemplateFolders.DeleteAsync(folderId);

            return View();
        }

        public ActionResult GetAllTemplateFolders(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Folder>> result = null;

            if (request != null)
                result = mailChimpManager.TemplateFolders.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetTemplateFolder(string folderId, BaseRequest request = null)
        {
            Task<Folder> result = null;

            if (request != null)
                result = mailChimpManager.TemplateFolders.GetAsync(folderId, request);

            return View(result.Result);
        }

        public ActionResult GetTemplateFolderResponse(QueryableBaseRequest request = null)
        {
            Task<TemplateFolderResponse> result = null;

            if (request != null)
                result = mailChimpManager.TemplateFolders.GetResponseAsync(request);

            return View(result.Result);
        }

        public ActionResult UpdateCampaignFolder(string folderId, string folderName)
        {
            Task<Folder> result = null;

            if (folderId != null && folderName != null)
                result = mailChimpManager.TemplateFolders.UpdateAsync(folderId, folderName);

            return View(result.Result);
        }
    }
}