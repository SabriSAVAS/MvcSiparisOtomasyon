using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Core.DataAccess.EntityFramework;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.DataAccess.Concrete.EntityFramework
{
  public  class EfOrderDetailDal:EfEntityRepositoryBase<OrderDetail,SipEntegrasyonContext>, IOrderDetailDal
    {
        public void OrderDetailAllRemove(List<OrderDetail> ordersDetails)
        {
            using (SipEntegrasyonContext db=new SipEntegrasyonContext())
            {
                foreach (var ordersDetail in ordersDetails)
                {
                    var order = db.OrderDetails.FirstOrDefault(x=>x.Id==ordersDetail.Id);
                    if (order!=null)
                    {
                        db.OrderDetails.Remove(order);
                        db.SaveChanges();
                    }
                 
                }
            }
        }
    }
}
