using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.ApiManager;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class FileManagerFilesController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddFile(string name, string folderId, string base64String)
        {
            Task<FileManagerFile> result = null;

            if (name != null && folderId != null && base64String != null)
                result = mailChimpManager.FileManagerFiles.AddAsync(name, folderId, base64String);

            return View(result.Result);
        }

        public ActionResult AddFile(string fileName, string folderId, Stream fileStream)
        {
            Task<FileManagerFile> result = null;

            if (fileName != null && folderId != null && fileStream != null)
                result = mailChimpManager.FileManagerFiles.AddAsync(fileName, folderId, fileStream);

            return View(result.Result);
        }

        public ActionResult AddFileManageFile(string name, string folderId, string fileName)
        {
            Task<FileManagerFile> result = null;

            if (name != null && folderId != null && fileName != null)
                result = mailChimpManager.FileManagerFiles.AddFileAsync(fileName, folderId, fileName);

            return View(result.Result);
        }

        public ActionResult DeleteList(string fileId)
        {
            if (fileId != null)
                mailChimpManager.FileManagerFiles.DeleteAsync(fileId);

            return View();
        }

        public ActionResult GetAllFileManagerFiles(FileManagerRequest request = null)
        {
            Task<IEnumerable<FileManagerFile>> result = null;
            result = mailChimpManager.FileManagerFiles.GetAllAsync(request);

            return View(result.Result);
        }

        public ActionResult GetFileManagerFile(string fileId, BaseRequest request = null)
        {
            Task<FileManagerFile> result = null;

            if (fileId != null)
                result = mailChimpManager.FileManagerFiles.GetAsync(fileId);

            return View(result.Result);
        }

        public ActionResult GetListResponse(FileManagerRequest request = null)
        {
            Task<FileManagerFileResponse> result = null;
            result = mailChimpManager.FileManagerFiles.GetResponseAsync(request);

            return View(result.Result);
        }

        public ActionResult UpdateFile(string fileId, string name, string folderId, string base64String)
        {
            Task<FileManagerFile> result = null;

            if (fileId != null && name != null && folderId != null && base64String != null)
                result = mailChimpManager.FileManagerFiles.UpdateAsync(fileId, name, folderId, base64String);

            return View(result.Result);
        }

        public ActionResult UpdateFile(string fileId, string name, string folderId, Stream stream)
        {
            Task<FileManagerFile> result = null;

            if (fileId != null && name != null && folderId != null && stream != null)
                result = mailChimpManager.FileManagerFiles.UpdateAsync(fileId, name, folderId, stream);

            return View(result.Result);
        }

        public ActionResult UpdateFileManagerFile(string fileId, string name, string folderId, Stream stream)
        {
            Task<FileManagerFile> result = null;

            if (fileId != null && name != null && folderId != null && stream != null)
                result = mailChimpManager.FileManagerFiles.UpdateAsync(fileId, name, folderId, stream);

            return View(result.Result);
        }
    }
}