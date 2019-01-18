using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
   public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int Id);
        Brand Add(Brand product);
        Brand Update(Brand product);
        void Delete(Brand product);
    }
}
