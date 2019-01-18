using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SiparisEnt.Dto.CustomerVM
{
    public class CustomerModel:BaseModel
    {
        public CustomerModel()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            CityList =new List<SelectListItem>();
        }
        [Required(ErrorMessage = "Müsteri unvanı alanı gereklidir.")]
        public string Name { get; set; }
        public string TaxOffice { get; set; }

        public string TaxNumber { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi")]
        public string eMail { get; set; }

        public string Country { get; set; }

        [Required(ErrorMessage = "Şehir alanı gereklidir.")]
        public int CityId { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public int? UserId { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
