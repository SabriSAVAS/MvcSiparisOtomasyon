using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Core.DataAccess.EntityFramework;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SipEntegrasyonContext>, IUserDal
    {
        //public bool PasswordChange(User user)
        //{
        //    using (SipEntegrasyonContext db=new SipEntegrasyonContext())
        //    {
        //        user.Password=
        //        db.SaveChanges();
        //    }
        //}
        public User IsVaildUser(string eMail, string password)
        {
            using (SipEntegrasyonContext db = new SipEntegrasyonContext())
            {
                var result = db.Users.FirstOrDefault(x => x.eMail == x.eMail.Trim() & x.Password == password.Trim() & x.IsActive == true);
                return result;
            }
        }

        public List<UserRoleItem> GetUserRoleItems(User user)
        {
            using (SipEntegrasyonContext db = new SipEntegrasyonContext())
            {
                //var result = from ur in db.UserRoleMappings
                //    join r in db.Roles
                //        on ur.UserId equals user.Id
                //    where ur.UserId == user.Id
                //    select new UserRoleItem { RoleName = r.Name };
                var result = new List<UserRoleItem>();
                var roleMappings = db.UserRoleMappings.Where(x => x.UserId == user.Id);
                foreach (var roleMapping in roleMappings)
                {
                    UserRoleItem roleItem = new UserRoleItem();
                    var rolename = db.Roles.Where(x => x.Id == roleMapping.RoleId);
                    roleItem.RoleName = rolename.FirstOrDefault().Name;
                    result.Add(roleItem);
                }                            
                return result.ToList();
            }
        }
    }
}
