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
    public class MergeFieldsApi
    {

        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public MergeField AddMergeFields(string listId, MergeField member)
        {
            Task<MergeField> result = null;

            if (listId != null && member != null)
                result = mailChimpManager.MergeFields.AddAsync(listId, member);

            return result.Result;
        }

        public void DeleteList(string listId, int mergeId)
        {
            if (listId != null && mergeId != 0)
                mailChimpManager.MergeFields.DeleteAsync(listId, mergeId);
        }

        public IEnumerable<MergeField> GetAllMergeFields(string listId, MergeFieldRequest request = null)
        {
            Task<IEnumerable<MergeField>> result = null;

            if(listId != null)
                result = mailChimpManager.MergeFields.GetAllAsync(listId, request);

            return result.Result;
        }


        public MergeField GetMergeField(string listId, int mergeId, MergeFieldRequest request = null)
        {
            Task<MergeField> result = null;

            if (listId != null && mergeId != 0)
                result = mailChimpManager.MergeFields.GetAsync(listId, mergeId, request);

            return result.Result;
        }

        public MergeFieldResponse GetResponse(string listId, MergeFieldRequest request = null)
        {
            Task<MergeFieldResponse> result = null;

            if(listId != null)
            result = mailChimpManager.MergeFields.GetResponseAsync(listId, request);

            return result.Result;
        }


        public MergeField AddMergeFields(string listId, MergeField mergeField, int? mergeId = null)
        {
            Task<MergeField> result = null;

            if (listId != null && mergeField != null)
                result = mailChimpManager.MergeFields.UpdateAsync(listId, mergeField, mergeId);

            return result.Result;
        }
    }
}