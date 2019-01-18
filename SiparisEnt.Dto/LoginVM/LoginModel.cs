using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SiparisEnt.Dto.LoginVM
{
    public class LoginModel
    {
        [Required]
        public string eMail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
