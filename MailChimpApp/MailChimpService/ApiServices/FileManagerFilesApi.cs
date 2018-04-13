using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpService.ApiManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MailChimpService.ApiServices
{
    public class FileManagerFilesApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public FileManagerFile AddFile(string name, string folderId, string base64String)
        {
            Task<FileManagerFile> result = null;

            if (name != null && folderId != null && base64String != null)
                result = mailChimpManager.FileManagerFiles.AddAsync(name, folderId, base64String);

            return result.Result;
        }

        public FileManagerFile AddFile(string fileName, string folderId, Stream fileStream)
        {
            Task<FileManagerFile> result = null;

            if (fileName != null && folderId != null && fileStream != null)
                result = mailChimpManager.FileManagerFiles.AddAsync(fileName, folderId, fileStream);

            return result.Result;
        }

        public FileManagerFile AddFileManageFile(string name, string folderId, string fileName)
        {
            Task<FileManagerFile> result = null;

            if (name != null && folderId != null && fileName != null)
                result = mailChimpManager.FileManagerFiles.AddFileAsync(fileName, folderId, fileName);

            return result.Result;
        }

        public void DeleteList(string fileId)
        {
            if (fileId != null)
                mailChimpManager.FileManagerFiles.DeleteAsync(fileId);
        }

        public IEnumerable<FileManagerFile> GetAllFileManagerFiles(FileManagerRequest request = null)
        {
            Task<IEnumerable<FileManagerFile>> result = null;
            result = mailChimpManager.FileManagerFiles.GetAllAsync(request);

            return result.Result;
        }

        public FileManagerFile GetFileManagerFile(string fileId, BaseRequest request = null)
        {
            Task<FileManagerFile> result = null;

            if (fileId != null)
                result = mailChimpManager.FileManagerFiles.GetAsync(fileId);

            return result.Result;
        }

        public FileManagerFileResponse GetListResponse(FileManagerRequest request = null)
        {
            Task<FileManagerFileResponse> result = null;
            result = mailChimpManager.FileManagerFiles.GetResponseAsync(request);

            return result.Result;
        }

        public FileManagerFile UpdateFile(string fileId, string name, string folderId, string base64String)
        { 
        Task<FileManagerFile> result = null;

            if (fileId != null && name != null && folderId != null && base64String != null)
                result = mailChimpManager.FileManagerFiles.UpdateAsync(fileId, name, folderId, base64String);

            return result.Result;
        }

        public FileManagerFile UpdateFile(string fileId, string name, string folderId, Stream stream)
        {
            Task<FileManagerFile> result = null;

            if (fileId != null && name != null && folderId != null && stream != null)
                result = mailChimpManager.FileManagerFiles.UpdateAsync(fileId, name, folderId, stream);

            return result.Result;
        }

        public FileManagerFile UpdateFileManagerFile(string fileId, string name, string folderId, Stream stream)
        {
            Task<FileManagerFile> result = null;

            if (fileId != null && name != null && folderId != null && stream != null)
                result = mailChimpManager.FileManagerFiles.UpdateAsync(fileId, name, folderId, stream);

            return result.Result;
        }

    }
}