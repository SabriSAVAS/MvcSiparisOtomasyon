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
   public class StatusManager: IStatusService
   {
       private EfStatusDal _efStatusDal;

       public StatusManager(EfStatusDal efStatusDal)
       {
           _efStatusDal = efStatusDal;
       }

       public List<Status> GetAll()
       {
           return _efStatusDal.GetList();
       }
   }
}
