using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace SiparisEnt.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAutCookie(int Id, string userName, string email, DateTime expiration, string[] roles,
            bool rememberMe, string firstName, string lastName)
        {
            var autTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe,
                CreatAuthTags(email, roles, firstName, lastName, Id));
            string encTicket = FormsAuthentication.Encrypt(autTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        private static string CreatAuthTags(string email, string[] roles, string firstName, string lastName, int id)
        {
            var sb = new StringBuilder();
            sb.Append(email);
            sb.Append('|');
            for (int i = 0; i < roles.Length; i++)
            {

                sb.Append(roles[i]);
                if (i < roles.Length - 1)
                {
                    sb.Append(',');
                }

            }
            sb.Append('|');
            sb.Append(firstName);
            sb.Append('|');
            sb.Append(lastName);
            sb.Append('|');
            sb.Append(id);
            return sb.ToString();
        }
    }
}
