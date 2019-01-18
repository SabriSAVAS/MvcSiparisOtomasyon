using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace SiparisEnt.Dto.CatalogVM
{
    public class CustomerPopupModel
    {
        public string CusName { get; set; }
        public int? Page { get; set; }
        public IPagedList<CustomerListPopup> CustomerListPopups { get; set; }
    }
}
