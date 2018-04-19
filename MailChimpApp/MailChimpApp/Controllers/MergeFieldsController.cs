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
    public class MergeFieldsController : Controller
    {
        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddMergeFields(string listId, MergeField member)
        {
            Task<MergeField> result = null;

            if (listId != null && member != null)
                result = mailChimpManager.MergeFields.AddAsync(listId, member);

            return View(result.Result);
        }

        public ActionResult DeleteList(string listId, int mergeId)
        {
            if (listId != null && mergeId != 0)
                mailChimpManager.MergeFields.DeleteAsync(listId, mergeId);

            return View();
        }

        public ActionResult GetAllMergeFields(string listId, MergeFieldRequest request = null)
        {
            Task<IEnumerable<MergeField>> result = null;

            if (listId != null)
                result = mailChimpManager.MergeFields.GetAllAsync(listId, request);

            return View(result.Result);
        }

        public ActionResult GetMergeField(string listId, int mergeId, MergeFieldRequest request = null)
        {
            Task<MergeField> result = null;

            if (listId != null && mergeId != 0)
                result = mailChimpManager.MergeFields.GetAsync(listId, mergeId, request);

            return View(result.Result);
        }

        public ActionResult GetResponse(string listId, MergeFieldRequest request = null)
        {
            Task<MergeFieldResponse> result = null;

            if (listId != null)
                result = mailChimpManager.MergeFields.GetResponseAsync(listId, request);

            return View(result.Result);
        }


        public ActionResult AddMergeFields(string listId, MergeField mergeField, int? mergeId = null)
        {
            Task<MergeField> result = null;

            if (listId != null && mergeField != null)
                result = mailChimpManager.MergeFields.UpdateAsync(listId, mergeField, mergeId);

            return View(result.Result);
        }
    }
}