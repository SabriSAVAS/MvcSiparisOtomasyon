using FluentValidation.Mvc;
using SiparisEnt.Business.DependencyResolvers.Ninject;
using SiparisEnt.Core.CrossCuttingConcerns.Security.Web;
using SiparisEnt.Core.Utilities.Mvc.Infrastructure;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace SiparisEnt.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(),new AutoMapperModule()));
            FluentValidationModelValidatorProvider.Configure(provider =>
                {
                    provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule());
                });

        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, System.EventArgs e)
        {
            try
            {
                var autCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (autCookie == null)
                {
                   return;
                }

                string encTicket = autCookie.Value;
                if (string.IsNullOrEmpty(encTicket))
                {
                   return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securityUtilities = new SecurityUtilities();
                var Identity = securityUtilities.FormsAutTicketToIdentity(ticket);
              
                var principal = new GenericPrincipal(Identity, Identity.Roles);
                  
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal  = principal;
            }
            catch
            {
                
            }

          

        }
    }
}