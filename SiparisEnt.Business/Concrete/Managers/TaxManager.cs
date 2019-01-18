using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Core.Aspects.Postsharp.CacheAspects;
using SiparisEnt.Core.CrossCuttingConcerns.Caching.Microsoft;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Concrete.Managers
{
   public class TaxManager:ITaxService
   {
       private ITaxDal _taxDal;

       public TaxManager(ITaxDal taxDal)
       {
           _taxDal = taxDal;
       }
       [CacheAspect(typeof(MemoryCacheManager),120)]
        public List<Tax> GetAll()
       {
           return _taxDal.GetList();
       }

       public Tax GetById(int Id)
       {
           return _taxDal.Get(x => x.Id.Equals(Id));
       }

       public Tax Add(Tax product)
       {
           throw new NotImplementedException();
       }

       public Tax Update(Tax product)
       {
           throw new NotImplementedException();
       }

       public void Delete(Tax product)
       {
           throw new NotImplementedException();
       }
   }
}
