using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Core.DataAccess.EntityFramework;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.DataAccess.Concrete.EntityFramework
{
   public class EfStatusDal:EfEntityRepositoryBase<Status,SipEntegrasyonContext>, IStatusDal
    {
    }
}
