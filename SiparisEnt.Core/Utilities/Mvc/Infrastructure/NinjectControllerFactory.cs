using Ninject;
using Ninject.Modules;
using System;
using System.Security.Policy;
using System.Web.Mvc;
using System.Web.Routing;

namespace SiparisEnt.Core.Utilities.Mvc.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory(params INinjectModule[] modules)
        {
            _kernel = new StandardKernel(modules);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
           
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
}
