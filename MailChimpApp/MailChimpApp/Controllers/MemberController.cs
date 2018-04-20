using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpApp.ApiManager;
using MailChimpApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MailChimpApp.Controllers
{
    public class MemberController : Controller
    {
        /// <summary>
        /// MemberController is to organize our members. 
        /// We can subscribe, unsubscribe, get all member... etc.  
        /// Also we can check out and search members.
        /// </summary>

        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        public ActionResult AddSubscribe(string listId, Member member)
        {
            //string listId = "c97e72b500";
            if (listId != null && member != null)
            {
                member.StatusIfNew = Status.Subscribed;
                mailChimpManager.Members.AddOrUpdateAsync(listId, member);

                return RedirectToAction("GetAllMember", "Member" , new { listId = listId });
            }
            return View("AddSubscribe");
        }

        public ActionResult DeleteMember(string listId, string emailAddress)
        {
            if (listId != null && emailAddress != null)
                mailChimpManager.Members.DeleteAsync(listId, emailAddress);

            return RedirectToAction("GetAllMember", new { listId = listId });
        }

        public ActionResult GetAllMember(string listId)
        {
            Task<IEnumerable<Member>> result = null;
            if (listId != null)
                result = mailChimpManager.Members.GetAllAsync(listId);
            ViewBag.listId = listId;

            return View(result.Result);
        }

        public async Task<ActionResult> ExistsMember(string listId, string emailAddress)
        {
            bool existsMember = false;
            if (listId != null && emailAddress != null)
                existsMember = await mailChimpManager.Members.ExistsAsync(listId, emailAddress);

            return View(existsMember);
        }

        public ActionResult GetMemberActivities(string listId, string emailAddress)
        {
            Task<IEnumerable<Activity>> result = null;
            if (listId != null && emailAddress != null)
                result = mailChimpManager.Members.GetActivitiesAsync(listId, emailAddress);

            return View(result.Result);
        }

         public async Task<ActionResult> GetMember(string listId, string emailAddress)
        {
            Member result = null;
            if (listId != null && emailAddress != null)
               result = await mailChimpManager.Members.GetAsync(listId, emailAddress);

            return View(result);
        }

        public async Task<ActionResult> GetTotalItem(string listId, Status status)
        {
            int totalItem = 0;

            if (listId != null)
                totalItem = await mailChimpManager.Members.GetTotalItems(listId, status);

            return View(totalItem);
        }

        public ActionResult SearchMember(string query, string listId)
        {
            Task<MemberSearchResult> result = null;

            MemberSearchRequest request = new MemberSearchRequest
            { Query = query, ListId = listId };

            if (request != null)
                result = mailChimpManager.Members.SearchAsync(request);

            return View(result.Result);
        }

    }
}