using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Entities.Concrete
{
  public  class UserRoleMapping:EntityBase
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

    }
}
