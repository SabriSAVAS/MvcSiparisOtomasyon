using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.ValidationRules.FluentValidation
{
  public class AccountValidator : AbstractValidator<User>
    {
        public AccountValidator()
        {
            RuleFor(a => a.FirstName).NotNull();
            RuleFor(a => a.LastName).NotNull();
            RuleFor(a => a.eMail).NotNull().EmailAddress();
            
        }
    }
}
