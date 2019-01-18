using System;
using System.ComponentModel.DataAnnotations;

namespace SiparisEnt.Dto.AccountVM
{
    public class AccountModel:BaseModel
    {
        public AccountModel()
        {
            LoginDate=DateTime.Now;
            CreateDate=DateTime.Now;
            IsActive = true;
        }
        [Required(ErrorMessage = "Kullanıcı adı alanı gereklidir.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyadı adı alanı gereklidir.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "ePosta alanı gereklidir.")]
        [EmailAddress]
        public string eMail { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [Compare("Password",ErrorMessage = "Şifre eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ConfirimPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        
    }
}
