using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetUserRoleRepository: IGenericRepository<UsersRole, int>
    {
        private readonly IDbConnection _con;
        public AdoNetUserRoleRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
        }
               
        public IEnumerable<UsersRole> GetAll()
        {
            List<UsersRole> listUsersRoles;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[dicUsersRoles]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listUsersRoles = new List<UsersRole> { };


                    while (dataReader.Read())
                    {
                        listUsersRoles.Add
                              (
                              new UsersRole(
                              int.Parse(dataReader["UserRoleId"].ToString().Trim()),
                              dataReader["UserRoleName"].ToString().Trim()                                                       
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
            return listUsersRoles;

            
        }

        public UsersRole GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[dicUsersRoles] where UserRoleId={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new UsersRole(
                                       int.Parse(dataReader["UserRoleId"].ToString().Trim()),
                                       dataReader["UserRoleName"].ToString().Trim()                                      
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[dicUsersRoles] where UserRoleId={0}", key);

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

        public bool Change(UsersRole entity)
        {

            var command = _con.CreateCommand();
            command.CommandText = string.Format("update dicUsersRoles " +
                "set UserRoleName='{0}' where UserRoleId={1}"
                , entity.UserRoleName, entity.UserRoleId);
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

        public bool Add(UsersRole entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[dicUsersRoles] (UserRoleName)  " +
                "VALUES( '{0}')",
                entity.UserRoleName  );
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
