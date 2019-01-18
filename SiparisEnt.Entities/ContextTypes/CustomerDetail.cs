using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Entities.ContextTypes
{
    public class CustomerDetail : EntityBase
    {
        public string Name { get; set; }

        public string TaxOffice { get; set; }


        public string TaxNumber { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string eMail { get; set; }

        public string Country { get; set; }

        public int? CityId { get; set; }
        public string CityName { get; set; }
        public int? UserId { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
