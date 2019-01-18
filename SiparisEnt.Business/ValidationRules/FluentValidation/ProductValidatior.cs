using FluentValidation;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.ValidationRules.FluentValidation
{
    public  class ProductValidatior: AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı giriniz.");
            RuleFor(p => p.ProductCode).NotEmpty().WithMessage("Ürün kodu giriniz.");
            RuleFor(p => p.UnitId).NotEmpty().WithMessage("Ürün birimini giriniz.");
            
        }
    }
}
