using System.Collections.Generic;
using SiparisEnt.Core.DataAccess;
using SiparisEnt.Entities.Concrete;
using SiparisEnt.Entities.ContextTypes;

namespace SiparisEnt.DataAccess.Abstarct
{
    public interface IOrderBasketDal:IEntityRepository<OrderBasket>
    {
        List<OrderDetailBasket> GetOrderDetailBaskets();
    }
}
