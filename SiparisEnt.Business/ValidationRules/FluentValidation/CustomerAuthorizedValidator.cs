using FluentValidation;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.ValidationRules.FluentValidation
{
    public class CustomerAuthorizedValidator:AbstractValidator<CustomerAuthorized>
    {
        public CustomerAuthorizedValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Yetikli adı gereklidir.");
           
        }
    }
}
