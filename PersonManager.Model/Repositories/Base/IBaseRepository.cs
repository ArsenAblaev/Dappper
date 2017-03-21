using System.Collections.Generic;

namespace PersonManager.Model.Repositories.Base
{
    public interface IBaseRepository<TEntity>
    {
        IList<TEntity> GetUsers();
        TEntity Get(int id);
        TEntity Create(TEntity user);
        void Update(TEntity user);
        void Delete(int id);
    }
}
