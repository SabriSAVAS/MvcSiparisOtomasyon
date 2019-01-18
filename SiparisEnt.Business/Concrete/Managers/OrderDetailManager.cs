using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Core.Aspects.Postsharp.CacheAspects;
using SiparisEnt.Core.Aspects.Postsharp.ExceptionAspects;
using SiparisEnt.Core.CrossCuttingConcerns.Caching.Microsoft;
using SiparisEnt.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Concrete.Managers
{
    public class OrderDetailManager : IOrderDetailService
    {
        private EfOrderDetailDal _efOrderDetailDal;

        public OrderDetailManager(EfOrderDetailDal efOrderDetailDal)
        {
            _efOrderDetailDal = efOrderDetailDal;
        }
      
        public OrderDetail Add(OrderDetail orderDetail)
        {
            return _efOrderDetailDal.Add(orderDetail);
        }

        public bool Delete(OrderDetail orderDetail)
        {
            return _efOrderDetailDal.Delete(orderDetail);
        }

        public void DeleteAll(List<OrderDetail> orderDetails)
        {
            _efOrderDetailDal.OrderDetailAllRemove(orderDetails);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        public List<OrderDetail> GetAll()
        {
            return _efOrderDetailDal.GetList();
        }

        public OrderDetail GetById(int Id)
        {
            return _efOrderDetailDal.Get(x => x.Id == Id);
        }

        public List<OrderDetail> GetOrderById(int Id)
        {
            return _efOrderDetailDal.GetList(x => x.OrderId == Id);
        }

        public OrderDetail Update(OrderDetail detail)
        {
            return _efOrderDetailDal.Update(detail);
        }
    }
}
