using System;

namespace SiparisEnt.Entities.Concrete
{
    [Serializable]
    public class Customer : EntityBase
    {
        public Customer()
        {
            CreatedDate=DateTime.Now;
            IsActive = true;
        }
        public string Name { get; set; }

        
        public string TaxOffice { get; set; }

       
        public string TaxNumber { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string eMail { get; set; }

        public string Country { get; set; }

        public int? CityId { get; set; }

        public int? UserId { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}