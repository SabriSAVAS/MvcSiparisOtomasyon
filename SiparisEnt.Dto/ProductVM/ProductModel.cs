using SiparisEnt.Entities.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SiparisEnt.Dto.ProductVM
{

    public class ProductModel : BaseModel

    {
        public ProductModel()
        {
            
            BrandList = new List<SelectListItem>();
            UnitList = new List<SelectListItem>();
            CategoryList = new List<SelectListItem>();
            ExcList = new List<SelectListItem>();
            TaxList = new List<SelectListItem>();
            Product=new Product();
        }
        public List<SelectListItem> TaxList { get; set; }
        public List<SelectListItem> ExcList { get; set; }
        public List<SelectListItem> BrandList { get; set; }
        public List<SelectListItem> UnitList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public Product  Product { get; set; }
    }

}
