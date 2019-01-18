using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
    public interface IDeliveryService
    {
        List<Delivery> GetAll();
    }
}
