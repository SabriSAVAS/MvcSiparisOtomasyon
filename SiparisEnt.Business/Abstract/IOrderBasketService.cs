using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Abstract
{
   public interface IOrderBasketService
   {
       OrderBasket Add(OrderBasket orderBasket);
       OrderBasket Update(OrderBasket orderBasket);
       bool Delete(OrderBasket orderBasket);
        List<OrderBasket> GetAll();
       OrderBasket GetById(int Id);
        List<OrderDetailBasket> GetOrderDetailBaskets();
    }
}
