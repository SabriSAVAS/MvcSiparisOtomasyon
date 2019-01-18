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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [CacheAspect(typeof(MemoryCacheManager), 120)]
        public List<Brand> GetAll()
        {
            return _brandDal.GetList();
        }

        public Brand GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Brand Add(Brand product)
        {
            throw new NotImplementedException();
        }

        public Brand Update(Brand product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand product)
        {
            throw new NotImplementedException();
        }
    }
}
