using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Abstract
{
   public interface IOrderService
   {
       List<OrderDetailItem> GetOrderDetailItems();
       List<OrderDetailItem> GetTop10OrderDetailItems();
        Order Add(Order order);
       int GetOrderSerial(string orderSerail);
       Order GetById(int id);
       bool Delete(Order order);
       Order Update(Order order);

       bool OrderIsCustomerControl(int customerId);
       int GetNewPaddingOrder();
       int GetCompletedOrder();
       int GetPreparedOrder();
       int GetOrdersShipped();
       decimal GetCompletedOrderTotal();
   }
}
