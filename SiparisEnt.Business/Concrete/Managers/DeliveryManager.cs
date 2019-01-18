using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Concrete.Managers
{
   public class DeliveryManager: IDeliveryService
   {
       private EfDeliveryDal _efDeliveryDal;

       public DeliveryManager(EfDeliveryDal efDeliveryDal)
       {
           _efDeliveryDal = efDeliveryDal;
       }

       public List<Delivery> GetAll()
       {
           return _efDeliveryDal.GetList();
       }
   }
}
