using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Core.DataAccess;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.DataAccess.Abstarct
{
   public interface IOrderDal:IEntityRepository<Order>
    {
        List<OrderDetailItem> GetOrderDetailItems(int takelist=200);
        int GetOrderSira(string orderseri);
        bool OrderIsCustomerControl(int customerId);
        decimal GetCompletedOrderTotal();
    }
}
