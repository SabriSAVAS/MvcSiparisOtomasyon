using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SiparisEnt.Dto.AccountVM
{
   public class AccountChangePasswordModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [Compare("Password", ErrorMessage = "Şifre eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ChangePassword { get; set; }
    }
}
