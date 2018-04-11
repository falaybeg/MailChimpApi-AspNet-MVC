
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MailChimpApp.ApiMailChimp
{
    public class ListSegment
    {

        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        //public ListSegment AddListSegment(string listId, Segment segment)
        //{
        //    Task<ListSegment> result = null;

        //    if (listId != null && segment != null)
        //       // result = mailChimpManager.ListSegments.AddAsync(listId, segment);

        //    return result.Result;
        //}
    }
}