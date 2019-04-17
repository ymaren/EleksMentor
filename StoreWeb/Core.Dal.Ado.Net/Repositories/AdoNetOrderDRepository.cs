using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetOrderDRepository: IGenericRepository<OrderD, int>
    {
        private readonly IDbConnection _con;
        public AdoNetOrderDRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
        }
               
        public IEnumerable<OrderD> GetAll()
        {
            List<OrderD> listOrderD;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[tblOrderD]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listOrderD = new List<OrderD> { };


                    while (dataReader.Read())
                    {
                        listOrderD.Add
                              (
                              new OrderD(
                              int.Parse(dataReader["OrderDid"].ToString().Trim()),
                              int.Parse(dataReader["OrderHid"].ToString().Trim()),
                              int.Parse(dataReader["Productid"].ToString().Trim()),
                              int.Parse(dataReader["OrderQTY"].ToString().Trim()),
                              double.Parse(dataReader["ProductPrice"].ToString().Trim()),
                              double.Parse(dataReader["ProductSum"].ToString().Trim())                             
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
            return listOrderD;

            
        }

        public OrderD GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[tblOrderD] where OrderDid={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new OrderD(
                                      int.Parse(dataReader["OrderDid"].ToString().Trim()),
                                      int.Parse(dataReader["OrderHid"].ToString().Trim()),
                                      int.Parse(dataReader["Productid"].ToString().Trim()),
                                      int.Parse(dataReader["OrderQTY"].ToString().Trim()),
                                      double.Parse(dataReader["ProductPrice"].ToString().Trim()),
                                      double.Parse(dataReader["ProductSum"].ToString().Trim())
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[tblOrderD] where OrderDid={0}", key);

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

        public bool Change(OrderD entity)
        {

            var command = _con.CreateCommand();
            command.CommandText = string.Format("update tblOrderD " +
                "set OrderHid='{1}', Productid='{2}',OrderQTY={3}, ProductPrice={4}, ProductSum={5}  where OrderDid={0}",
                entity.OrderDid,
                entity.OrderHid,
                entity.Productid,
                entity.OrderQTY, 
                entity.ProductPrice, entity.ProductSum);
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

        public bool Add(OrderD entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[tblOrderD] " +
                "(OrderHid ,Productid,OrderQTY,ProductPrice,ProductSum)  " +
                "VALUES( '{0}', '{1}', {2}, {3},{4})",
                entity.OrderHid, entity.Productid, entity.OrderQTY, entity.ProductPrice, entity.ProductSum);
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
