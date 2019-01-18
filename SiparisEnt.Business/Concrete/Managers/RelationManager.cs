using System.Collections.Generic;
using SiparisEnt.Business.Abstract;
using SiparisEnt.DataAccess.Concrete.EntityFramework;
using SiparisEnt.Entities.Concrete;

namespace SiparisEnt.Business.Concrete.Managers
{
   public class RelationManager: IRelationService
   {
       private EfRelationDal _efRelationDal;

       public RelationManager(EfRelationDal efRelationDal)
       {
           _efRelationDal = efRelationDal;
       }

       public List<Relation> GetList()
       {
           return _efRelationDal.GetList();
       }

        public Relation Insert(Relation entity)
        {
            return _efRelationDal.Add(entity);
        }

        public Relation Update(Relation entity)
        {
            return _efRelationDal.Update(entity);
        }

        public bool Delete(Relation entity)
        {
            return _efRelationDal.Delete(entity);
        }
    }
}
