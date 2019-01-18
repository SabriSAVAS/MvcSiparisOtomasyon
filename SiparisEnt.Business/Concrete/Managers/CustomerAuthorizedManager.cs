using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Business.ValidationRules.FluentValidation;
using SiparisEnt.Core.Aspects.Postsharp.ValidationAspects;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Concrete.Managers
{
    public class CustomerAuthorizedManager : ICustomerAuthorizedService
    {
        private EfCustomerAuthorizedDal _customerAuthorizedDal;

        public CustomerAuthorizedManager(EfCustomerAuthorizedDal customerAuthorizedDal)
        {
            _customerAuthorizedDal = customerAuthorizedDal;
        }

        public List<CustomerAuthorized> GetCustomerById(int customerId)
        {
            return _customerAuthorizedDal.GetList(x => x.CustomerId == customerId);
        }
        [FluentValidationAspect(typeof(CustomerAuthorizedValidator))]
        public CustomerAuthorized Add(CustomerAuthorized entity)
        {
            return _customerAuthorizedDal.Add(entity);
        }

        public CustomerAuthorized Update(CustomerAuthorized entity)
        {
            return _customerAuthorizedDal.Update(entity);
        }

        public bool Delete(CustomerAuthorized entity)
        {
            return _customerAuthorizedDal.Delete(entity);
        }
    }
}
