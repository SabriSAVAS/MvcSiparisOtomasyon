using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Entities.Concrete
{
   public class CustomerAuthorized:EntityBase
    {      
        public string FirstName { get; set; }
  
        public string LastName { get; set; }

        public string Phone { get; set; }
    
        public string eMail { get; set; }

        public string Description { get; set; }

        public int CustomerId { get; set; }

    }
}
