using SiparisEnt.Business.Abstract;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;
using System;
using System.Collections.Generic;
using SiparisEnt.Core.Aspects.Postsharp.CacheAspects;
using SiparisEnt.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace SiparisEnt.Business.Concrete.Managers
{
    public  class CityManager:ICityService
  {
      private ICityDal _cityDal;

      public CityManager(ICityDal cityDal)
      {
          _cityDal = cityDal;
      }
      [CacheAspect(typeof(MemoryCacheManager), 120)]
        public List<City> GetAll()
      {
          return _cityDal.GetList();
      }
    }
}
