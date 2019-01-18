using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Business.ValidationRules.FluentValidation;
using SiparisEnt.Core.Aspects.Postsharp.AuthorizationAspects;
using SiparisEnt.Core.Aspects.Postsharp.CacheAspects;
using SiparisEnt.Core.Aspects.Postsharp.ValidationAspects;
using SiparisEnt.Core.CrossCuttingConcerns.Caching.Microsoft;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Concrete.Managers
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
      
        [CacheAspect(typeof(MemoryCacheManager))]
       // [SecuredOperation(Roles = "CustomerRead")]
        public List<Customer> GetAll()
        {
            return _customerDal.GetList();
        }

        public Customer GetById(int Id)
        {
            return _customerDal.Get(x => x.Id == Id);
        }
        [FluentValidationAspect(typeof(CustomerValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        //[SecuredOperation(Roles = "CustomerAdd")]
        public Customer Add(Customer customer)
        {
            return _customerDal.Add(customer);
        }
        [FluentValidationAspect(typeof(CustomerValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        //[SecuredOperation(Roles = "CustomerUpdate")]
        public Customer Update(Customer customer)
        {
            return _customerDal.Update(customer);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        //[SecuredOperation(Roles = "CustomerRead")]
        public List<CustomerDetail> GetCustomerDetailAll()
        {
            return _customerDal.GetCustomerDetail();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        //[SecuredOperation(Roles = "CustomerDelete")]
        public bool Delete(Customer customer)
        {
            return _customerDal.Delete(customer);
        }
    }
}
