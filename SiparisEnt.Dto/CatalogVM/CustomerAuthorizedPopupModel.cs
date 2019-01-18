using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Dto.CatalogVM
{
  public  class CustomerAuthorizedPopupModel
    {
        public CustomerAuthorizedPopupModel()
        {
            CustomerAuthorizedList=new List<CustomerAuthorized>();
        }
        public List<CustomerAuthorized> CustomerAuthorizedList { get; set; }
    }
}
