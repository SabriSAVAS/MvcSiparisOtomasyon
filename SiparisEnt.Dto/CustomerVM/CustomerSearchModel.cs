using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace SiparisEnt.Dto.CustomerVM
{
    public class CustomerSearchModel
    {
        public string CustomerName { get; set; }
        public IPagedList<CustomerDetailModel> CustomerDetailModelList { get; set; }
        public int? Page { get; set; }
    }
}
