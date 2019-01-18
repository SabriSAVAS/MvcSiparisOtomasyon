using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
  public  interface ITaxService
    {
        List<Tax> GetAll();
        Tax GetById(int Id);
        Tax Add(Tax product);
        Tax Update(Tax product);
        void Delete(Tax product);
    }
}
