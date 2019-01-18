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
   public class UnitManager:IUnitService
   {
       private IUnitDal _unitDal;

       public UnitManager(IUnitDal unitDal)
       {
           _unitDal = unitDal;
       }

       [CacheAspect(typeof(MemoryCacheManager), 120)]
        public List<Unit> GetAll()
       {
           return _unitDal.GetList();
       }

       public Unit GetById(int Id)
       {
           return _unitDal.Get(x => x.Id == Id);
       }

       public Unit Add(Unit product)
       {
           throw new NotImplementedException();
       }

       public Unit Update(Unit product)
       {
           throw new NotImplementedException();
       }

       public void Delete(Unit product)
       {
           throw new NotImplementedException();
       }

      
   }
}
