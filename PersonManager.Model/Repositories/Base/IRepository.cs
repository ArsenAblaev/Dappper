using System.Collections.Generic;

namespace PersonManager.Model.Repositories.Base
{
    public interface IRepository<TEntity> 
    {
        List<TEntity> GetList();
        TEntity Get(int id);
        TEntity Create(TEntity user);
        void Update(TEntity user);
        void Delete(int id);
    }
}
