namespace HomemadeORM.Contracts
{
    using System.Collections.Generic;

    public interface IDbContext
    {
        bool Persist(object entity);

        T FindById<T>(int id);

        IEnumerable<T> FindAll<T>();

        IEnumerable<T> FindAll<T>(string where);

        T FindFirst<T>();

        T FindFirst<T>(string where);
    }
}
