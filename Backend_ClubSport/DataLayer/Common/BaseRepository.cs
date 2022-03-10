using ClubSport.Domain;
using Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Common
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly ClubSportContext dbContext;
        public BaseRepository(ClubSportContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TEntity Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            TEntity entity = new TEntity
            {
                Id = id
            };
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }

        public TEntity Update(int id,TEntity entity)
        {
            TEntity newentity = new TEntity
            {
                Id = id
            };
            dbContext.Update(entity);
            dbContext.SaveChanges();
            return entity;

        }
    }
}
