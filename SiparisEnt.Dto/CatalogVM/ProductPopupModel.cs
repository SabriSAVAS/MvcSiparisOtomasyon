using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace SiparisEnt.Dto.CatalogVM
{
   public class ProductPopupModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? Page { get; set; }
        public IPagedList<ProductListPopup> ProductListPopups { get; set; }
    }
}
