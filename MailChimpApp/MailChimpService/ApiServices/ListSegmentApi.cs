using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using MailChimpService.ApiManager;

namespace MailChimpService.ApiServices
{
    class ListSegmentApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();

        public ListSegment AddListegment(string listId, Segment segment)
        {
            Task<ListSegment> result = null;
            if(listId != null && segment != null)
             result = mailChimpManager.ListSegments.AddAsync(listId, segment);
            
            return result.Result;
        }

        public Member AddListSegmentMember(string listId, string segmentId, Member member)
        {
            Task<Member> result = null;

            if (listId != null && segmentId != null && member != null)
                result = mailChimpManager.ListSegments.AddMemberAsync(listId, segmentId, member);

            return result.Result;
        }

        public BatchSegmentMembersResponse BatchMember(string listId, string segmentId, BatchSegmentMembers batchSegmentMembers)
        {
            Task<BatchSegmentMembersResponse> result = null;

            if (listId != null && segmentId != null && batchSegmentMembers != null)
                result = mailChimpManager.ListSegments.BatchMemberAsync(listId, segmentId, batchSegmentMembers);

            return result.Result;
        }

        public void DeleteListSegment(string listId, string segmentId)
        {
            if (listId != null && segmentId != null)
                mailChimpManager.ListSegments.DeleteAsync(listId, segmentId);
        }

        public void DeleteList(string listId, string segmentId, string emailAddressOrHash)
        {
            if (listId != null && segmentId != null && emailAddressOrHash != null)
                mailChimpManager.ListSegments.DeleteMemberAsync(listId, segmentId, emailAddressOrHash);
        }

        public IEnumerable<ListSegment> GetAllListSegments(string listId, ListSegmentRequest request = null)
        {
            Task<IEnumerable<ListSegment>> result = null;
            if (listId != null)
                result = mailChimpManager.ListSegments.GetAllAsync(listId);

            return result.Result;
        }

        public IEnumerable<Member> GetAllListSegmentMembers(string listId, string segmentId, ListSegmentRequest request = null)
        {
            Task<IEnumerable<Member>> result = null;
            if (listId != null && segmentId != null)
                result = mailChimpManager.ListSegments.GetAllMembersAsync(listId, segmentId, request);

            return result.Result;
        }


        public ListSegment GetListSegment(string listId, int segmentId)
        {
            Task<ListSegment> result = null;

            if (listId != null && segmentId != 0)
                result = mailChimpManager.ListSegments.GetAsync(listId, segmentId);

            return result.Result;
        }

        public MemberResponse GetListSegmentMemberResponse(string listId, string segmentId, QueryableBaseRequest request = null)
        {
            Task<MemberResponse> result = null;

            if (listId != null && segmentId != null)
                result = mailChimpManager.ListSegments.GetMemberResponseAsync(listId, segmentId, request);

            return result.Result;
        }

        public ListSegmentResponse GetListSegmentResponse(string listId, ListSegmentRequest request = null)
        {
            Task<ListSegmentResponse> result = null;

            if (listId != null)
                result = mailChimpManager.ListSegments.GetResponseAsync(listId, request);

            return result.Result;
        }

        public ListSegment UpdateListSegment(string listId, string segmentId, Segment segment)
        {
            Task<ListSegment> result = null;

            if (listId != null && segmentId != null && segment != null)
                result = mailChimpManager.ListSegments.UpdateAsync(listId, segmentId, segment);

            return result.Result;
        }

    }
}
