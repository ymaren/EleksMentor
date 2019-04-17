using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetProductCategoryRepository : IGenericRepository<ProductCategory, int>
    {
        private readonly IDbConnection _con;
        public AdoNetProductCategoryRepository(IDbConnection connection)
        {
            this._con = connection;

            _con.Open();
        }
               
        public IEnumerable<ProductCategory> GetAll()
        {
            List<ProductCategory> listCategory;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[dicProductCategory]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listCategory = new List<ProductCategory> { };


                    while (dataReader.Read())
                    {
                        listCategory.Add
                              (
                              new ProductCategory(
                              int.Parse(dataReader["CategoryId"].ToString()),
                              dataReader["CategoryName"].ToString(),
                              dataReader["CategoryDescription"].ToString()
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
            return listCategory;

       }

        public ProductCategory GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[dicProductCategory] where id={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new ProductCategory(
                                       int.Parse(dataReader["CategoryId"].ToString()),
                                       dataReader["CategoryName"].ToString(),
                                       dataReader["CategoryDescription"].ToString()
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[dicProductCategory] where CategoryId={0}", key);

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

        public bool Change(int key)
        {
            throw new NotImplementedException();
        }

        public bool Add(ProductCategory entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[dicProductCategory] (CategoryName,CategoryDescription)  " +
                "VALUES( '{0}', '{1}')", entity.CategoryName, entity.CategoryDescription);
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

        public bool Change(ProductCategory entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("update dicProductCategory " +
                "set CategoryName='{0}', CategoryDescription='{1}'  where CategoryId = {2}"
                , entity.CategoryName, entity.CategoryDescription,entity.CategoryId);
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
