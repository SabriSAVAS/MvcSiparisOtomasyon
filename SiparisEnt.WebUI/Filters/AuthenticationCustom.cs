using System;
using System.Linq;
using System.Web;
using SiparisEnt.WebUI.Infrastructure.AccountHelpers;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Filters
{
    public class AuthenticationCustom : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var roles = AccountHelper.GetAccount().Roles;
            string methodName = filterContext.ActionDescriptor.ActionName;


            var isTrue = roles.Where(x => x.Contains(methodName)).ToList().Count > 0;
            if (!isTrue)
            {

                HttpContext.Current.Response.Redirect("/Other/Forbidden403");
                
            }
            //base.OnActionExecuting(filterContext);
        }

        //public void OnActionExecuted(ActionExecutedContext filterContext)
        //{

        //    throw new NotImplementedException();

        //}

        //public void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var roles = AccountHelper.GetAccount().Roles;
        //    string methodName = filterContext.ActionDescriptor.ActionName;


        //    var isTrue = roles.Where(x => x.Contains(methodName)).ToList().Count > 0;
        //    if (!isTrue)
        //    {

        //        HttpContext.Current.Response.Redirect("/Other/Forbidden403");
        //    }

        //}
    }
}