using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
  public  interface IExcService
    {
        List<Exc> GetAll();
        Exc GetById(int Id);
        Exc Add(Exc product);
        Exc Update(Exc product);
        void Delete(Exc product);
    }
}
