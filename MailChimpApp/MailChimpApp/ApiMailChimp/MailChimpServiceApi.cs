using MailChimp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailChimpApp.ApiMailChimp
{
    public class MailChimpServiceApi
    {

        static string apiKey = "fe128428f5207b8936c9b6e026c6f5b2-us18";
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