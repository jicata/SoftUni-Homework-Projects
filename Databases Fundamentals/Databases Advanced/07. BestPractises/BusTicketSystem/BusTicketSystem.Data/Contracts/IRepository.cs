using System;
using System.Collections.Generic;

namespace BusTicketSystem.Models.Contracts
{
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);


    }
}
