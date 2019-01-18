using System.Linq;
using SiparisEnt.Core.DataAccess.EntityFramework;
using SiparisEnt.DataAccess.Abstarct;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, SipEntegrasyonContext>, IProductDal
    {
        
        public bool GetProductCodeControl(string paramater)
        {
            using (SipEntegrasyonContext db=new SipEntegrasyonContext())
            {

                var result= db.Products.Any(x => x.ProductCode.Contains(paramater.ToLower().Trim()));
                return result;
            }
        }
    }
}