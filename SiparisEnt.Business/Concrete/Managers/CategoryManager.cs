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
  public  class CategoryManager:ICategoryService
  {
      private ICategoryDal _categoryDal;

      public CategoryManager(ICategoryDal categoryDal)
      {
          _categoryDal = categoryDal;
      }

      [CacheAspect(typeof(MemoryCacheManager), 120)]
        public List<Category> GetAll()
      {
          return _categoryDal.GetList();
      }

      public Category GetById(int Id)
      {
          throw new NotImplementedException();
      }

      public Category Add(Category product)
      {
          throw new NotImplementedException();
      }

      public Category Update(Category product)
      {
          throw new NotImplementedException();
      }

      public void Delete(Category product)
      {
          throw new NotImplementedException();
      }
  }
}
