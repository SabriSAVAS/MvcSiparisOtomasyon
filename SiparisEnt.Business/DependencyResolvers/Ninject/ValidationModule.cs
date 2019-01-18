using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ninject.Modules;
using SiparisEnt.Business.ValidationRules.FluentValidation;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.DependencyResolvers.Ninject
{
  public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<CustomerAuthorized>>().To<CustomerAuthorizedValidator>().InSingletonScope();
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope();
            Bind<IValidator<Order>>().To<OrderValidator>().InSingletonScope();
        }
    }
}
