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
    public class LimitApi
    {
        IMailChimpManager mailChimpManager = MailChimpServiceApi.MailChimpService();


        public int Limit()
        {
            return mailChimpManager.Limit;
        }



        
    }
}