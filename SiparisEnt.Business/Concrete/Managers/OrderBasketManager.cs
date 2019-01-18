using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Concrete.Managers
{
   public class OrderBasketManager:IOrderBasketService
   {
       private EfOrderBasketDal _efOrderBasketDal;

       public OrderBasketManager(EfOrderBasketDal efOrderBasketDal)
       {
           _efOrderBasketDal = efOrderBasketDal;
       }

       public OrderBasket Add(OrderBasket orderBasket)
       {
           return _efOrderBasketDal.Add(orderBasket);
       }

       public OrderBasket Update(OrderBasket orderBasket)
       {
           return _efOrderBasketDal.Update(orderBasket);
       }

       public bool Delete(OrderBasket orderBasket)
       {
           return _efOrderBasketDal.Delete(orderBasket);
       }

       public List<OrderBasket> GetAll()
       {
           return _efOrderBasketDal.GetList();
       }

       public OrderBasket GetById(int Id)
       {
           return _efOrderBasketDal.Get(x => x.Id == Id);
       }

       public List<OrderDetailBasket> GetOrderDetailBaskets()
       {
           return _efOrderBasketDal.GetOrderDetailBaskets();
       }
   }
}
