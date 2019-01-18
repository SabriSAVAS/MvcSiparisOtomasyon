using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Infrastructure.Attribute
{
    public class LoginControl: ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                    filterContext.HttpContext.Response.Redirect("/Login"); 
                   
                }

               
               
          

            }
            catch (Exception)
            {
                filterContext.HttpContext.Response.Redirect("/Login");

            }
        }
    }
}