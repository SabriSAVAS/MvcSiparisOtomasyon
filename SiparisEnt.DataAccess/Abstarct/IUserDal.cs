using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Core.DataAccess;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.DataAccess.Abstarct
{
  public  interface IUserDal: IEntityRepository<User>
  {
      //bool PasswordChange(User user);
      User IsVaildUser(string eMail, string password);
      List<UserRoleItem> GetUserRoleItems(User user);
  }
}
