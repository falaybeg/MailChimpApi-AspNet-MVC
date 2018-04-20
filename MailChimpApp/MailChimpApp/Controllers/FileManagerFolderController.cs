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
    public class FileManagerFolderController : Controller
    {
        /// <summary>
        /// Here we can create, delete... folder to organize our files.
        /// </summary>

        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddFileManagerFolder(string folderName)
        {
            Task<FileManagerFolder> result = null;

            if (folderName != null)
                result = mailChimpManager.FileManagerFolders.AddAsync(folderName);

            return View(result.Result);
        }

        public ActionResult DeleteList(string folderId)
        {
            if (folderId != null)
                mailChimpManager.FileManagerFolders.DeleteAsync(folderId);

            return View();
        }

        public ActionResult GetAllFolders(FileManagerRequest request = null)
        {
            Task<IEnumerable<FileManagerFolder>> result = null;
            result = mailChimpManager.FileManagerFolders.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetFolder(string folderId, BaseRequest request = null)
        {
            Task<FileManagerFolder> result = null;

            if (folderId != null)
                result = mailChimpManager.FileManagerFolders.GetAsync(folderId);

            return View(result.Result);
        }

        public ActionResult UpdateFolder(string folderId, string folderName)
        {
            Task<FileManagerFolder> result = null;

            if (folderId != null && folderName != null)
                result = mailChimpManager.FileManagerFolders.UpdateAsync(folderId, folderName);

            return View(result.Result);
        }

        public ActionResult GetFolderResponse(FileManagerRequest request = null)
        {
            Task<FileManagerFolderResponse> result = null;
            result = mailChimpManager.FileManagerFolders.GetResponseAsync(request);

            return View(result.Result);
        }
    }
}