using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Core.Aspects.Postsharp.CacheAspects;
using SiparisEnt.Core.CrossCuttingConcerns.Caching.Microsoft;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Concrete.Managers
{
   public class ExcManager:IExcService
   {
       private IExcDal _excDal;

       public ExcManager(IExcDal excDal)
       {
           _excDal = excDal;
       }
       [CacheAspect(typeof(MemoryCacheManager), 120)]
        public List<Exc> GetAll()
       {
           return _excDal.GetList();
       }

        public Exc GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Exc Add(Exc product)
        {
            throw new NotImplementedException();
        }

        public Exc Update(Exc product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Exc product)
        {
            throw new NotImplementedException();
        }
    }
}
