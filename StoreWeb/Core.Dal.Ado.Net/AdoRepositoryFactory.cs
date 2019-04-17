
using Core.Dal.Ado.Net.Repositories;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net
{
    public class AdoRepositoryFactory:IRepositoryFactory
    {
        private readonly string _constring;
        public AdoRepositoryFactory(string connection)
        {
            this._constring = connection;
        }

        private readonly static Dictionary<Type, Func<IDbConnection, IRepository>> _supportedObjects 
            = new Dictionary<Type, Func<IDbConnection, IRepository>>
        {
            [typeof(Product)] = (connection) => new AdoNetProductRepository(connection),
            [typeof(ProductCategory)] = (connection) => new AdoNetProductCategoryRepository(connection),
            [typeof(ProductGroup)] = (connection) => new AdoNetProductGroupRepository(connection),
            [typeof(User)] = (connection) => new AdoNetUserRepository(connection),
            [typeof(UsersRole)] = (connection) => new AdoNetUserRoleRepository(connection),
            [typeof(UsersCredential)] = (connection) => new AdoNetUserCredentialRepository(connection),
            [typeof(OrderType)] = (connection) => new AdoNetOrderTypeRepository(connection),
            [typeof(OrderH)] = (connection) => new AdoNetOrderHRepository(connection),
            [typeof(OrderD)] = (connection) => new AdoNetOrderDRepository(connection),
            
                
            };

        public IGenericRepository<TEntity, Key> CreateRepository<TEntity, Key>()
        {
            System.Func<IDbConnection, IRepository> delegateFactory = null;
            if (_supportedObjects.TryGetValue(typeof(TEntity), out delegateFactory))
            {
                return (IGenericRepository<TEntity, Key>)delegateFactory(new SqlConnection(_constring));
            }

            throw new System.NotImplementedException();
        }

        


    }
}
