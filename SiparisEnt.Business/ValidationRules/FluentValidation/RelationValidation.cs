using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.ValidationRules.FluentValidation
{
    public class RelationValidation: AbstractValidator<Relation>
    {
        public RelationValidation()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.AuthorizedId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.Priority).NotEmpty();
            RuleFor(r => r.CustomerType).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.ResponsibleStaff).NotEmpty();
            RuleFor(r => r.StartClock).NotEmpty();
            RuleFor(r => r.EndClock).NotEmpty();
            RuleFor(r => r.StartDate).NotEmpty();
            RuleFor(r => r.EndDate).NotEmpty();
            RuleFor(r => r.RelationshipType).NotEmpty();
            
        }
    }
}
