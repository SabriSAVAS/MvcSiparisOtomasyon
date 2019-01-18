using Ninject.Modules;
using SiparisEnt.Business.Abstract;
using SiparisEnt.Business.Concrete.Managers;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Business.DependencyResolvers.Ninject
{
   public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IBrandService>().To<BrandManager>();
            Bind<IBrandDal>().To<EfBrandDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IUnitService>().To<UnitManager>().InSingletonScope();
            Bind<IUnitDal>().To<EfUnitDal>().InSingletonScope();

            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();

            Bind<ITaxService>().To<TaxManager>().InSingletonScope();
            Bind<ITaxDal>().To<EfTaxDal>().InSingletonScope();

            Bind<IExcService>().To<ExcManager>().InSingletonScope();
            Bind<IExcDal>().To<EfExcDal>().InSingletonScope();

            Bind<ICityService>().To<CityManager>().InSingletonScope();
            Bind<ICityDal>().To<EfCityDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IOrderService>().To<OrderManager>().InSingletonScope();
            Bind<IOrderDal>().To<EfOrderDal>().InSingletonScope();

            Bind<IOrderBasketService>().To<OrderBasketManager>().InSingletonScope();
            Bind<IOrderBasketDal>().To<EfOrderBasketDal>().InSingletonScope();

            Bind<IOrderDetailService>().To<OrderDetailManager>().InSingletonScope();
            Bind<IOrderDetailDal>().To<EfOrderDetailDal>().InSingletonScope();

            Bind<IDeliveryService>().To<DeliveryManager>().InSingletonScope();
            Bind<IDeliveryDal>().To<EfDeliveryDal>().InSingletonScope();

            Bind<IStatusService>().To<StatusManager>().InSingletonScope();
            Bind<IStatusDal>().To<EfStatusDal>().InSingletonScope();

            Bind<ICustomerAuthorizedService>().To<CustomerAuthorizedManager>().InSingletonScope();
            Bind<ICustomerAuthorizedDal>().To<EfCustomerAuthorizedDal>().InSingletonScope();




            Bind<DbContext>().To<SipEntegrasyonContext>().InSingletonScope();
           
        }
    }
}
