using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Dto.ProductVM
{
  public  class ProductSearchModel
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public IPagedList<Product> ProdcutList { get; set; }
        public int? Page { get; set; }
    }
}
