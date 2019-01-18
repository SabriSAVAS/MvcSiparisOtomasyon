using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Core.DataAccess;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.DataAccess.Abstarct
{
    public  interface IUnitDal:IEntityRepository<Unit>
    {
    }
}
