using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Business.ValidationRules.FluentValidation;
using SiparisEnt.Core.Aspects.Postsharp.AuthorizationAspects;
using SiparisEnt.Core.Aspects.Postsharp.CacheAspects;
using SiparisEnt.Core.Aspects.Postsharp.ValidationAspects;
using SiparisEnt.Core.CrossCuttingConcerns.Caching.Microsoft;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Concrete.Managers
{
    public class OrderManager : IOrderService
    {
        private EfOrderDal _efOrderDal;

        public OrderManager(EfOrderDal efOrderDal)
        {
            _efOrderDal = efOrderDal;
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<OrderDetailItem> GetOrderDetailItems()
        {
            return _efOrderDal.GetOrderDetailItems();
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<OrderDetailItem> GetTop10OrderDetailItems()
        {
            return _efOrderDal.GetOrderDetailItems(5);
        }
        [FluentValidationAspect(typeof(OrderValidator))]
        [SecuredOperation(Roles = "Order.Add")]
        public Order Add(Order order)
        {
            return _efOrderDal.Add(order);
        }

        public int GetOrderSerial(string orderSerial)
        {
            return _efOrderDal.GetOrderSira(orderSerial);
        }

        public Order GetById(int Id)
        {
            return _efOrderDal.Get(x => x.Id == Id);
        }

        [SecuredOperation(Roles = "Order.Delete")]
        public bool Delete(Order order)
        {
            return _efOrderDal.Delete(order);
        }
        [FluentValidationAspect(typeof(OrderValidator))]
        [SecuredOperation(Roles = "Order.Update")]
        public Order Update(Order order)
        {
            return _efOrderDal.Update(order);
        }

        public bool OrderIsCustomerControl(int customerId)
        {
            return _efOrderDal.OrderIsCustomerControl(customerId);
        }

        public int GetNewPaddingOrder()
        {
            return _efOrderDal.GetList(x => x.StatusId == 1).Count;
        }

        public int GetCompletedOrder()
        {
            return _efOrderDal.GetList(x => x.StatusId == 10).Count;
        }

        public int GetPreparedOrder()
        {
            return _efOrderDal.GetList(x => x.StatusId == 6).Count;
        }

        public int GetOrdersShipped()
        {
            return _efOrderDal.GetList(x => x.StatusId == 8).Count;
        }

        public decimal GetCompletedOrderTotal()
        {
            return _efOrderDal.GetCompletedOrderTotal();
        }
    }
}
