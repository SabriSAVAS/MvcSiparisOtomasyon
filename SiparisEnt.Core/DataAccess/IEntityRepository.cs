using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SiparisEnt.Core.Entities;

namespace SiparisEnt.Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);

        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
    
    }
}