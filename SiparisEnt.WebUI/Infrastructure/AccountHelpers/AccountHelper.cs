using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SiparisEnt.Core.CrossCuttingConcerns.Security;
using SiparisEnt.Core.CrossCuttingConcerns.Security.Web;

namespace SiparisEnt.WebUI.Infrastructure.AccountHelpers
{
    public class AccountHelper
    {
        public static Identity GetAccount()
        {
            var autCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (autCookie == null)
            {

            }

            string encTicket = autCookie.Value;
            if (string.IsNullOrEmpty(encTicket))
            {


            }

            var ticket = FormsAuthentication.Decrypt(encTicket);

            var securityUtilities = new SecurityUtilities();
            var Identity = securityUtilities.FormsAutTicketToIdentity(ticket);
            return Identity;
        }
    }
}