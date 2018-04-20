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
    public class ListSegmentController : Controller
    {
        /// <summary>
        /// ListSegment is to target subscribers by location, engagement, activity... etc
        /// </summary>

        IMailChimpManager mailChimpManager = MailChimApiManager.MailChimpService();

        /// <summary>
        /// Create a ListSegment 
        /// </summary>
        /// <param name="listId">To create a listSegment listId is required</param>
        /// <param name="segment"></param>
        /// <returns></returns>
        public ActionResult AddListegment(string listId, Segment segment)
        {
            Task<ListSegment> result = null;
            if (listId != null && segment != null)
                result = mailChimpManager.ListSegments.AddAsync(listId, segment);

            return View(result.Result);
        }

        public ActionResult AddListSegmentMember(string listId, string segmentId, Member member)
        {
            Task<Member> result = null;

            if (listId != null && segmentId != null && member != null)
                result = mailChimpManager.ListSegments.AddMemberAsync(listId, segmentId, member);

            return View(result.Result);
        }

        public ActionResult BatchMember(string listId, string segmentId, BatchSegmentMembers batchSegmentMembers)
        {
            Task<BatchSegmentMembersResponse> result = null;

            if (listId != null && segmentId != null && batchSegmentMembers != null)
                result = mailChimpManager.ListSegments.BatchMemberAsync(listId, segmentId, batchSegmentMembers);

            return View(result.Result);
        }

        public ActionResult DeleteListSegment(string listId, string segmentId)
        {
            if (listId != null && segmentId != null)
                mailChimpManager.ListSegments.DeleteAsync(listId, segmentId);

            return View();
        }

        public ActionResult DeleteListSegmentMember(string listId, string segmentId, string emailAddressOrHash)
        {
            if (listId != null && segmentId != null && emailAddressOrHash != null)
                mailChimpManager.ListSegments.DeleteMemberAsync(listId, segmentId, emailAddressOrHash);

            return View();

        }

        public ActionResult GetAllListSegments(string listId, ListSegmentRequest request = null)
        {
            Task<IEnumerable<ListSegment>> result = null;
            if (listId != null)
                result = mailChimpManager.ListSegments.GetAllAsync(listId);

            return View(result.Result);
        }

        public ActionResult GetAllListSegmentMembers(string listId, string segmentId, ListSegmentRequest request = null)
        {
            Task<IEnumerable<Member>> result = null;
            if (listId != null && segmentId != null)
                result = mailChimpManager.ListSegments.GetAllMembersAsync(listId, segmentId, request);

            return View(result.Result);
        }


        public ActionResult GetListSegment(string listId, int segmentId)
        {
            Task<ListSegment> result = null;

            if (listId != null && segmentId != 0)
                result = mailChimpManager.ListSegments.GetAsync(listId, segmentId);

            return View(result.Result);
        }

        public ActionResult GetListSegmentMemberResponse(string listId, string segmentId, QueryableBaseRequest request = null)
        {
            Task<MemberResponse> result = null;

            if (listId != null && segmentId != null)
                result = mailChimpManager.ListSegments.GetMemberResponseAsync(listId, segmentId, request);

            return View(result.Result);
        }

        public ActionResult GetListSegmentResponse(string listId, ListSegmentRequest request = null)
        {
            Task<ListSegmentResponse> result = null;

            if (listId != null)
                result = mailChimpManager.ListSegments.GetResponseAsync(listId, request);

            return View(result.Result);
        }

        public ActionResult UpdateListSegment(string listId, string segmentId, Segment segment)
        {
            Task<ListSegment> result = null;

            if (listId != null && segmentId != null && segment != null)
                result = mailChimpManager.ListSegments.UpdateAsync(listId, segmentId, segment);

            return View(result.Result);
        }

    }
}