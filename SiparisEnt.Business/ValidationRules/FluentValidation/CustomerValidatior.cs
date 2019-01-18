using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.ValidationRules.FluentValidation
{
   public class CustomerValidatior : AbstractValidator<Customer>
    {
        public CustomerValidatior()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.CityId).NotNull();
            RuleFor(c => c.eMail).EmailAddress();
        }
    }
}
