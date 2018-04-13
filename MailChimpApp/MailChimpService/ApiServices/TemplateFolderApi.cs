using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpService.ApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MailChimpService.ApiServices
{
    public class TemplateFolderApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public Folder AddTemplateFolder(string folderName)
        {
            Task<Folder> result = null;
            if (folderName != null)
                result = mailChimpManager.TemplateFolders.AddAsync(folderName);

            return result.Result;
        }

        public void DeleteTemplateFolder(string folderId)
        {
            if (folderId != null)
                mailChimpManager.TemplateFolders.DeleteAsync(folderId);
        }


        public IEnumerable<Folder> GetAllTemplateFolders(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Folder>> result = null;

            if (request != null)
                result = mailChimpManager.TemplateFolders.GetAllAsync(request);

            return result.Result;
        }

        public Folder GetTemplateFolder(string folderId, BaseRequest request = null)
        {
            Task<Folder> result = null;

            if (request != null)
                result = mailChimpManager.TemplateFolders.GetAsync(folderId ,request);

            return result.Result;
        }

        public TemplateFolderResponse GetTemplateFolderResponse(QueryableBaseRequest request = null)
        {
            Task<TemplateFolderResponse> result = null;

            if (request != null)
                result = mailChimpManager.TemplateFolders.GetResponseAsync(request);

            return result.Result;
        }

        public Folder UpdateCampaignFolder(string folderId, string folderName)
        {
            Task<Folder> result = null;

            if (folderId != null && folderName != null)
                result = mailChimpManager.TemplateFolders.UpdateAsync(folderId ,folderName);

            return result.Result;
        }
    }
}