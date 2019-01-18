using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
  public  interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int Id);
        Category Add(Category product);
        Category Update(Category product);
        void Delete(Category product);
    }
}
