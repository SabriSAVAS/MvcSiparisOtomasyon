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
   public class EfOrderBasketDal: EfEntityRepositoryBase<OrderBasket,SipEntegrasyonContext>, IOrderBasketDal
    {
        public List<OrderDetailBasket> GetOrderDetailBaskets()
        {
            using (SipEntegrasyonContext db=new SipEntegrasyonContext())
            {
                var result = from dbOrderBasket in db.OrderBaskets
                    join dbProduct in db.Products on dbOrderBasket.ProductId equals dbProduct.Id
                    select new OrderDetailBasket
                    {
                        Id = dbOrderBasket.Id,
                        ProductName = dbProduct.ProductName,
                        Tax = dbOrderBasket.Tax,
                        UserId = dbOrderBasket.UserId,
                        Total = dbOrderBasket.Total,
                        Unit = dbOrderBasket.Unit,
                        DisCount = dbOrderBasket.DisCount,
                        ProductId = dbOrderBasket.ProductId,
                        UnitPrice = dbOrderBasket.UnitPrice,
                        Quantity = dbOrderBasket.Quantity,
                        DisCountTotal =dbOrderBasket.DisCountTotal,
                        Tax1Total = dbOrderBasket.Tax1Total,
                        Tax2Total = dbOrderBasket.Tax2Total,
                        Tax3Total = dbOrderBasket.Tax3Total,
                        Tax4Total = dbOrderBasket.Tax4Total


                    };
                return result.ToList();
            }
        }
    }
}
