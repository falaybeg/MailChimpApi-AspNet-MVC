using MailChimp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailChimpApp.ApiManager
{
    public class MailChimApiManager
    {

        static string apiKey = "Your-Api-Key";
        private static MailChimpManager mailChimpManager = null;

        public static MailChimpManager MailChimpService()
        {
            if (mailChimpManager == null)
            {
                mailChimpManager = new MailChimpManager(apiKey);
            }

            return mailChimpManager;
        }
    }
}