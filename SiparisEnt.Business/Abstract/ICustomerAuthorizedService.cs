using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
    public interface ICustomerAuthorizedService
    {
        List<CustomerAuthorized> GetCustomerById(int customerId);
        CustomerAuthorized Add(CustomerAuthorized entity);
        CustomerAuthorized Update(CustomerAuthorized entity);
        bool Delete(CustomerAuthorized entity);
    }
}
