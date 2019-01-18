using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Core.DataAccess.EntityFramework;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, SipEntegrasyonContext>, ICustomerDal
    {
        public List<CustomerDetail> GetCustomerDetail()
        {
            using (SipEntegrasyonContext db = new SipEntegrasyonContext())
            {
                var result = (from c in db.Customers
                              join city in db.Cities on c.CityId equals city.Id
                              select new CustomerDetail
                              {
                                  Name = c.Name,
                                  IsActive = c.IsActive,
                                  CreatedDate = c.CreatedDate,
                                  CityId = c.CityId,
                                  Id = c.Id,
                                  Address = c.Address,
                                  CityName = city.Name,
                                  Country = c.Country,
                                  Fax = c.Fax,
                                  Phone = c.Phone,
                                  TaxNumber = c.TaxNumber,
                                  TaxOffice = c.TaxOffice,
                                  UserId = c.UserId,
                                  eMail = c.eMail
                              }).ToList();
                return result;
            }

        }
    }
}
