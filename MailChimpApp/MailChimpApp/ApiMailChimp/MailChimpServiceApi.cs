using MailChimp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailChimpApp.ApiMailChimp
{
    public class MailChimpServiceApi
    {

        static string apiKey = "6410537375ac746f79ab4903e5ec316d-us18";
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