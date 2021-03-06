﻿using System;
using System.Collections.Generic;

namespace BusTicketSystem.Models.Repositories.Base
{
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Contracts;
    using Data;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BusTicketSystemContext context;

        public Repository(BusTicketSystemContext context)
        {
            this.context = context;
        }
        public virtual TEntity GetById(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return this.context.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().Where(predicate).AsEnumerable();
        }

        public virtual void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            this.context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            this.context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
