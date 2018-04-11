using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MailChimpApp.ApiMailChimp
{
    public class CampaignFolderApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public void DeleteCampaignFolder(string folderId)
        {
            if(folderId != null)
                mailChimpManager.CampaignFolders.DeleteAsync(folderId);
        }

        public Folder AddCampaignFolder(string folderName)
        {
            Task<Folder> result = null;
            if (folderName != null)
               result =  mailChimpManager.CampaignFolders.AddAsync(folderName);

            return result.Result;
        }

        public IEnumerable<Folder> AddCampaignFolder(QueryableBaseRequest request = null)
        {
            Task<IEnumerable<Folder>> result = null;

            if (request != null)
                result = mailChimpManager.CampaignFolders.GetAllAsync(request);

            return result.Result;
        }

        public Folder GetCampaignFolder(string folderId,  BaseRequest request = null)
        {
            Task<Folder> result = null;
            if (folderId != null)
                result = mailChimpManager.CampaignFolders.GetAsync(folderId, request);

            return result.Result;
        }

        public CampaignFolderResponse GetCampaignFolderResponse(QueryableBaseRequest request = null)
        {
            Task<CampaignFolderResponse> result = null;

            if (request != null)
                result = mailChimpManager.CampaignFolders.GetResponseAsync(request);

            return result.Result;
        }

        public Folder UpdateCampaignFolder(string folderId, string folderName)
        {
            Task<Folder> result = null;

            if (folderId != null && folderName != null)
                result = mailChimpManager.CampaignFolders.UpdateAsync(folderId, folderName);

            return result.Result;
        }
    }
}