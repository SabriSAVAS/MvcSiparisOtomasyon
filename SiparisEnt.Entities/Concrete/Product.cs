using System;

namespace SiparisEnt.Entities.Concrete
{
    public class Product : EntityBase
    {
        public Product()
        {
            CreatedDate=DateTime.Now;
            IsActive = true;
            Tax = 1;
        }
        public string ProductCode { get; set; }
       
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        
        public int Tax { get; set; }
        public string Exc { get; set; }

        public int? BrandId { get; set; }

        public int? UnitId { get; set; }

        public int? CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? IsActive { get; set; }


    }
}