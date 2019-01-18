using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User Add(User user);
        User Update(User user);
        User GetById(int Id);
        bool Delete(User user);
        //bool PasswordChange(User user);
        User IsVaildUser(string eMail, string password);
        List<UserRoleItem> GetUserRoleItems(User user);
    }
}
