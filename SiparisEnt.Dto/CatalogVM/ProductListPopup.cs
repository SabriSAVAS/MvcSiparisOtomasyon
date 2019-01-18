using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Dto.CatalogVM
{
   public class ProductListPopup:BaseModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
    }
}
