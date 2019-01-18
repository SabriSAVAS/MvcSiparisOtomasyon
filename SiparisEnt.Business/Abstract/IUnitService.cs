using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
   public interface IUnitService
    {
        List<Unit> GetAll();
        Unit GetById(int Id);
        Unit Add(Unit product);
        Unit Update(Unit product);
        void Delete(Unit product);
       
    }
}
