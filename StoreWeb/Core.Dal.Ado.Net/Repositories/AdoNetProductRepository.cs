using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetProductRepository: IGenericRepository<Product, int>
    {
        private readonly IDbConnection _con;
        public AdoNetProductRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
        }
               
        public IEnumerable<Product> GetAll()
        {
            List<Product> listLot;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[Products]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listLot = new List<Product> { };


                    while (dataReader.Read())
                    {
                        listLot.Add
                              (
                              new Product(
                              int.Parse(dataReader["Id"].ToString()),
                              dataReader["ProductCode"].ToString(),
                              dataReader["Name"].ToString(),
                              int.Parse(dataReader["Price"].ToString()),
                              dataReader["Description"].ToString(),
                              int.Parse(dataReader["GroupId"].ToString())                              
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
            return listLot;

            //List<Lot> products = new List<Lot> { };
            //products.Add(new Lot { Id = 1, CodeLot = "911", Name = "LOT1", Price = 100 });
            //products.Add(new Lot { Id = 2, CodeLot = "912", Name = "LOT2", Price = 200 });
            //products.Add(new Lot { Id = 3, CodeLot = "913", Name = "LOT3", Price = 300 });
            //return products; 
        }

        public Product GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[Lots] where id={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new Product(
                                       int.Parse(dataReader["Id"].ToString()),
                                       dataReader["ProductCode"].ToString(),
                                       dataReader["Name"].ToString(),
                                       int.Parse(dataReader["Price"].ToString()),
                                       dataReader["Description"].ToString(),
                                       int.Parse(dataReader["GroupId"].ToString())
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[Products] where id={0}", key);

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

        public bool Change(Product entity)
        {

            var command = _con.CreateCommand();
            command.CommandText = string.Format("update Products " +
                "set ProductCode='{0}', Name='{1}', Price={2}, Description='{3}', GroupId={4}  where Id = {5}"
                , entity.ProductCode, entity.Name, entity.Price, entity.Description, entity.GroupId, entity.Id);
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

        public bool Add(Product entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[Products] (ProductCode,[Name],Price,Description,GroupId)  " +
                "VALUES( '{0}', '{1}', {2}, '{3}', {4})", entity.ProductCode, entity.Name, entity.Price,entity.Description, entity.GroupId);
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
