using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.ValidationRules.FluentValidation
{
   public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Müşteri adı boş olamaz.");            
            RuleFor(x => x.DeliveryDate).NotEmpty().WithMessage("Teslim tarihi girilmesi zorunludur."); ;
            RuleFor(x => x.OrderNo).GreaterThan(0);
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.DeliveryId).NotEmpty();
            RuleFor(x => x.PayMethod).NotEmpty();
            RuleFor(x => x.ExchangeRate).NotEmpty();
            RuleFor(x => x.OrderDate)
                .NotEmpty()
                .WithMessage("Sipariş tarihi girilmesi zorunludur.");
            //.Must(BeAValidDate).WithMessage("Invalid Date");


        }
        private bool BeAValidDate(String value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
    }
}
