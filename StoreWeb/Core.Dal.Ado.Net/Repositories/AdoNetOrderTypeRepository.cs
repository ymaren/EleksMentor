using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetOrderTypeRepository: IGenericRepository<OrderType, int>
    {
        private readonly IDbConnection _con;
        public AdoNetOrderTypeRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
        }
               
        public IEnumerable<OrderType> GetAll()
        {
            List<OrderType> listOrderTypes;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[OrderType]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listOrderTypes = new List<OrderType> { };


                    while (dataReader.Read())
                    {
                        listOrderTypes.Add
                              (
                              new OrderType(
                             int.Parse(dataReader["OrderTypeId"].ToString().Trim()),
                              dataReader["OrderTypeName"].ToString().Trim()                                                       
                              )
                              );
                    }

                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            finally
            {
                _con.Close();
            }
            return listOrderTypes;

            
        }

        public OrderType GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[OrderType] where OrderTypeId={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new OrderType(
                                       int.Parse(dataReader["OrderTypeId"].ToString().Trim()),
                                       dataReader["OrderTypeName"].ToString().Trim()
                                       );
                    }

                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            return null;
        }

        public bool Delete(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("delete  [LotShop].[dbo].[OrderType] where OrderTypeId={0}", key);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            return false;
        }

        public void Dispose()
        {
            _con.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Change(OrderType entity)
        {

            var command = _con.CreateCommand();
            command.CommandText = string.Format("update OrderType " +
                "set OrderTypeName='{0}' where OrderTypeId={1}"
                , entity.OrderTypeName, entity.OrderTypeId);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public bool Add(OrderType entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[OrderType] (OrderTypeName)  " +
                "VALUES( '{0}')",
                entity.OrderTypeName  );
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
    }
}
