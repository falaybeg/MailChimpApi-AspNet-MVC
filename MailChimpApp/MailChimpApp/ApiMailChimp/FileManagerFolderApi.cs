using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace MailChimpApp.ApiMailChimp
{
    public class FileManagerFolderApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public FileManagerFolder AddFileManagerFolder(string folderName)
        {
            Task<FileManagerFolder> result = null;

            if (folderName != null)
                result = mailChimpManager.FileManagerFolders.AddAsync(folderName);

            return result.Result;
        }

        public void DeleteList(string folderId)
        {
            if (folderId != null)
                mailChimpManager.FileManagerFolders.DeleteAsync(folderId);
        }

        public IEnumerable<FileManagerFolder> GetAllFolders(FileManagerRequest request = null)
        {
            Task<IEnumerable<FileManagerFolder>> result = null;
            result = mailChimpManager.FileManagerFolders.GetAllAsync(request);

            return result.Result;
        }

        public FileManagerFolder GetFolder(string folderId, BaseRequest request = null)
        {
            Task<FileManagerFolder> result = null;

            if (folderId != null)
                result = mailChimpManager.FileManagerFolders.GetAsync(folderId);

            return result.Result;
        }

        public FileManagerFolder UpdateFolder(string folderId, string folderName)
        {
            Task<FileManagerFolder> result = null;

            if (folderId != null && folderName != null)
                result = mailChimpManager.FileManagerFolders.UpdateAsync(folderId, folderName);

            return result.Result;
        }

        public FileManagerFolderResponse GetFolderResponse(FileManagerRequest request = null)
        {
            Task<FileManagerFolderResponse> result = null;
            result = mailChimpManager.FileManagerFolders.GetResponseAsync(request);

            return result.Result;
        }
    }
}