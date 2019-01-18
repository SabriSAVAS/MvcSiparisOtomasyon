using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int Id);
        Customer Add(Customer product);
        Customer Update(Customer product);
        List<CustomerDetail> GetCustomerDetailAll();
        bool Delete(Customer product);
    }
}
