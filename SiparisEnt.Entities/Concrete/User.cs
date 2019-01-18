using System;

namespace SiparisEnt.Entities.Concrete
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string eMail { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

    }
}
