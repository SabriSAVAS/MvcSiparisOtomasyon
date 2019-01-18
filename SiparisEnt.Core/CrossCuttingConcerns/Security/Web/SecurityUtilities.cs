using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SiparisEnt.Core.CrossCuttingConcerns.Security.Web
{
   public class SecurityUtilities
    {
        public Identity FormsAutTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var Identity=new Identity
            {
                Id=setId(ticket),
                Name = setName(ticket),
                Email = setEmail(ticket),
                Roles = setRoles(ticket),
                FirstName = setFirstName(ticket),
                LastName = setLastName(ticket),
                AuthenticationType = setAutType(),
                IsAuthenticated = setIsAuthenticated()
                
            };
            return Identity;
        }

        private bool setIsAuthenticated()
        {
            return true;
        }

        private string setAutType()
        {
            return "Forms";
        }

        private string setLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3].ToString();
        }

        private string setFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2].ToString();
        }

        private string[] setRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles=data[1].Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

            return roles;

        }

        private string setEmail(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return data[0].ToString();
        }

        private string setName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private int setId(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return Convert.ToInt32(data[4]);
        }
    }
}
