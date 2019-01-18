using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using PostSharp.Aspects.Dependencies;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Business.ValidationRules.FluentValidation;
using SiparisEnt.Core.Aspects.Postsharp.AuthorizationAspects;
using SiparisEnt.Core.Aspects.Postsharp.CacheAspects;
using SiparisEnt.Core.Aspects.Postsharp.ExceptionAspects;
using SiparisEnt.Core.Aspects.Postsharp.LogAspects;
using SiparisEnt.Core.Aspects.Postsharp.ValidationAspects;
using SiparisEnt.Core.CrossCuttingConcerns.Caching.Microsoft;
using SiparisEnt.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using SiparisEnt.Core.Utilities.Mappings;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Dto.ProductVM;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Concrete.Managers
{
  
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }
        
        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles ="Product.Add")]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
       
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(ProductValidatior))]
        [SecuredOperation(Roles ="Product.Update")]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
        
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Product.Delete")]
        public bool Delete(Product product)
        {
            return _productDal.Delete(product);
        }
        public bool GetProductCodeControl(string productCode)
        {
            return _productDal.GetProductCodeControl(productCode);
        }

       
        public Product GetById(int Id)
        {
            return _productDal.Get(x => x.Id == Id);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [SecuredOperation(Roles = "Product.Read")]
        public List<Product> GetAll()
        {
            return _productDal.GetList().ToList();

        }


    }
}
