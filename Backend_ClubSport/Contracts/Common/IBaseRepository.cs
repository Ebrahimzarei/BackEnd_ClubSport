using ClubSport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts.Common
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        void Delete(int id);
        TEntity Add(TEntity entity);

        TEntity Update(int id,TEntity entity);
    }
}
