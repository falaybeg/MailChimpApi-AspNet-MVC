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
        IMailChimpManager memberApi = MailChimApiManager.MailChimpService();
        // GET: Member
        public ActionResult AddSubscribe(string listId, Member member)
        {
            //string listId = "c97e72b500";
            if (listId != null && member != null)
            {
                member.StatusIfNew = Status.Subscribed;
                memberApi.Members.AddOrUpdateAsync(listId, member);

                return RedirectToAction("GetAllMember", "Member" , new { listId = listId });
            }
            return View("AddSubscribe");
        }

        public ActionResult GetAllMember(string listId)
        {
            Task<IEnumerable<Member>> result = null;
            if (listId != null)
                result = memberApi.Members.GetAllAsync(listId);
            ViewBag.listId = listId;

            return View(result.Result);
        }

        public ActionResult DeleteMember(string listId, string emailAddress)
        {
            if (listId != null && emailAddress != null)
            {
                memberApi.Members.DeleteAsync(listId, emailAddress);
            }

            return RedirectToAction("GetAllMember", new { listId = listId});
        }

        public async Task<ActionResult> ExistsMember(string listId, string emailAddress)
        {
            bool existsMember = false;
            if (listId != null && emailAddress != null)
            {
                existsMember = await memberApi.Members.ExistsAsync(listId, emailAddress);
            }
            return View(existsMember);
        }

        public ActionResult GetMemberActivities(string listId, string emailAddress)
        {
            Task<IEnumerable<Activity>> result = null;
            if (listId != null && emailAddress != null)
            {
                result = memberApi.Members.GetActivitiesAsync(listId, emailAddress);
            }

            return View(result.Result);
        }

         public async Task<ActionResult> GetMember(string listId, string emailAddress)
        {
            Member result = null;
            if (listId != null && emailAddress != null)
               result = await memberApi.Members.GetAsync(listId, emailAddress);

            return View(result);
        }

        public async Task<ActionResult> GetTotalItem(string listId, Status status)
        {
            int totalItem = 0;

            if (listId != null)
            {
                totalItem = await memberApi.Members.GetTotalItems(listId, status);
            }

            return View(totalItem);
        }

        public async Task<ActionResult> SearchMember(string query, string listId)
        {
            Task<MemberSearchResult> result = null;

            MemberSearchRequest request = new MemberSearchRequest
            {
                Query = query, 
                ListId = listId
            };

            request = new MemberSearchRequest
            {
            };

            if (request != null)
            {
                result = memberApi.Members.SearchAsync(request);
            }

            return View(result.Result);
        }

    }
}