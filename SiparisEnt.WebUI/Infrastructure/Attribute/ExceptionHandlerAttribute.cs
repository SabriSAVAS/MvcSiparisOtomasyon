using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SiparisEnt.WebUI.Infrastructure.Alerts;

namespace SiparisEnt.WebUI.Infrastructure.Attribute
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            
            var message = filterContext.Exception.Message;

            if (filterContext.Exception is SecurityException)
            {
                filterContext.ExceptionHandled = true;

              
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Other"},
                    {"action", "Forbidden403"}
                });
            }

            else
            {
                filterContext.ExceptionHandled = true;

                filterContext.Controller.TempData["validation"] = message;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Other"},
                    {"action", "Error"}
                });
            }
            
            
            //filterContext.Controller.ViewData.ModelState.AddModelError("ValidationException", message);
            //filterContext.Result = new ViewResult
            //{
            //    ViewData = new ViewDataDictionary(filterContext.Controller.ViewData)
            //};
        }
    }
}