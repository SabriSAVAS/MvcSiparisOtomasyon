using SiparisEnt.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Business.Abstract
{
   public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int Id);
        Product Add(Product product);
        Product Update(Product product);
        bool Delete(Product product);
        bool GetProductCodeControl(string productCode);
      
    }
}
