using SiparisEnt.Core.DataAccess;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.DataAccess.Abstarct
{
    public interface IProductDal : IEntityRepository<Product>
    {
        bool GetProductCodeControl(string parameter);
    }
}