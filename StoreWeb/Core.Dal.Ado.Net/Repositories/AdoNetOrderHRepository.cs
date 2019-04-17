using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetOrderHRepository: IGenericRepository<OrderH, int>
    {
        private readonly IDbConnection _con;
        public AdoNetOrderHRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
        }
               
        public IEnumerable<OrderH> GetAll()
        {
            List<OrderH> listOrderH;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[tblOrderH]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listOrderH = new List<OrderH> { };


                    while (dataReader.Read())
                    {
                       listOrderH.Add
                              (
                              new OrderH(
                              int.Parse(dataReader["OrderId"].ToString().Trim()),
                              DateTime.Parse(dataReader["OrderDate"].ToString().Trim()),
                              dataReader["OrderNumber"].ToString().Trim(),
                              int.Parse(dataReader["OrderToUser"].ToString().Trim()),
                              int.Parse(dataReader["OrderTypeid"].ToString().Trim()),
                              double.Parse(dataReader["OrderAmount"].ToString().Trim())
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
            return listOrderH;

            
        }

        public OrderH GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[tblOrderH] where OrderId={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new OrderH(
                                       int.Parse(dataReader["OrderId"].ToString().Trim()),
                                       DateTime.Parse(dataReader["OrderDate"].ToString()),
                                       dataReader["OrderNumber"].ToString().Trim(),
                                       int.Parse(dataReader["OrderToUser"].ToString().Trim()),
                                       int.Parse(dataReader["OrderTypeid"].ToString().Trim()),
                                       int.Parse(dataReader["OrderAmount"].ToString().Trim())
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[tblOrderH] where OrderId={0}", key);

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

        public bool Change(OrderH entity)
        {

            var command = _con.CreateCommand();
            command.CommandText = string.Format("update tblOrderH " +
                "set OrderDate='{1}', OrderNumber='{2}',OrderToUser={3}, OrderTypeid={4}, OrderAmount={5}  where OrderId={0}"
                , entity.OrderId, entity.OrderDate.ToString("yyyyMMdd"), entity.OrderNumber, entity.OrderToUser, entity.OrderTypeid, entity.OrderAmount);
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

        public bool Add(OrderH entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[tblOrderH] " +
                "(OrderDate ,OrderNumber,OrderToUser,OrderTypeid,OrderAmount)  " +
                "VALUES( '{0}', '{1}', {2}, {3},{4})",
                entity.OrderDate.ToString("yyyyMMdd"), entity.OrderNumber, entity.OrderToUser, entity.OrderTypeid, entity.OrderAmount );
            try
            {
             // int add_id= (int)command.ExecuteScalar();
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
