using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Abstract
{
    public interface IRelationService
    {
        List<Relation> GetList();
        Relation Insert(Relation entity);
        Relation Update(Relation entity);
        bool Delete(Relation entity);

    }
}
