using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
   public interface IOrderDetailService
   {
       OrderDetail Add(OrderDetail orderDetail);
       bool Delete(OrderDetail orderDetail);
       void DeleteAll(List<OrderDetail> orderDetails);
        List<OrderDetail> GetAll();
       OrderDetail GetById(int id);
       List<OrderDetail> GetOrderById(int id);
       OrderDetail Update(OrderDetail detail);
   }
}
