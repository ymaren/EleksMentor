using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetProductGroupRepository : IGenericRepository<ProductGroup, int>
    {
        private readonly IDbConnection _con;
        public AdoNetProductGroupRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
            
        }
               
        public IEnumerable<ProductGroup> GetAll()
        {
            List<ProductGroup> listGroup;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[dicProductGroup]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listGroup = new List<ProductGroup> { };


                    while (dataReader.Read())
                    {
                        listGroup.Add
                              (
                              new ProductGroup(
                              int.Parse(dataReader["GroupId"].ToString()),
                              dataReader["GroupName"].ToString(),
                              dataReader["GroupDescription"].ToString(),
                              int.Parse(dataReader["CategoryId"].ToString())                              
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
            return listGroup;

       }

        public ProductGroup GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[dicProductGroup] where id={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new ProductGroup(
                                       int.Parse(dataReader["GroupId"].ToString()),
                                       dataReader["GroupName"].ToString(),
                                       dataReader["GroupDescription"].ToString(),
                                       int.Parse(dataReader["CategoryId"].ToString())
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[dicProductGroup] where GroupId={0}", key);

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

        public bool Add(ProductGroup entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[dicProductGroup] (GroupName,GroupDescription,CategoryId)  " +
                "VALUES( '{0}', '{1}', {2})", entity.GroupName, entity.GroupDescription,entity.CategoryId);
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

        public bool Change(ProductGroup entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("update dicProductGroup " +
                "set GroupName='{0}', GroupDescription='{1}' , CategoryId='{2}'  where GroupId = {3}"
                , entity.GroupName, entity.GroupDescription, entity.CategoryId, entity.GroupId);
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
