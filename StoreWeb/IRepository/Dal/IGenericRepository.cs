using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal
{
    public interface IGenericRepository<TEntity,tKey>:IRepository,IDisposable
    {
       TEntity GetSingle(tKey key);
       IEnumerable<TEntity> GetAll();

        bool Add(TEntity entity);
        bool Change(TEntity entity);
       bool Delete(tKey key);
    }
}
