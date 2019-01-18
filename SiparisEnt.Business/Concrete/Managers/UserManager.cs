using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Core.Aspects.Postsharp.AuthorizationAspects;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.Business.Concrete.Managers
{
    
    public class UserManager : IUserService
    {
        private EfUserDal _efUserDal;

        public UserManager(EfUserDal efUserDal)
        {
            _efUserDal = efUserDal;
        }
      
        public List<User> GetAll()
        {
            return _efUserDal.GetList();
        }
      
        public User Add(User user)
        {
            return _efUserDal.Add(user);
        }
        
        public User Update(User user)
        {
            return _efUserDal.Update(user);
        }

        public User GetById(int Id)
        {
            return _efUserDal.Get(x => x.Id == Id);
        }
       
        public bool Delete(User user)
        {
            return _efUserDal.Delete(user);
        }

        public User IsVaildUser(string eMail, string password)
        {
            return _efUserDal.IsVaildUser(eMail, password);
        }

        public List<UserRoleItem> GetUserRoleItems(User user)
        {
            return _efUserDal.GetUserRoleItems(user);
        }

        
    }
}
