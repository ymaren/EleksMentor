using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetUserRepository: IGenericRepository<User, int>
    {
        private readonly IDbConnection _con;
        public AdoNetUserRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
        }
               
        public IEnumerable<User> GetAll()
        {
            List<User> listUser;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[tblUsers]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listUser = new List<User> { };


                    while (dataReader.Read())
                    {
                        listUser.Add
                              (
                              new User(
                              int.Parse(dataReader["UserId"].ToString().Trim()),
                              dataReader["UserLogin"].ToString().Trim(),
                              dataReader["UserPassword"].ToString().Trim(),
                              dataReader["UserName"].ToString().Trim(),
                              int.Parse(dataReader["UserRoleid"].ToString().Trim())                              
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


            return listUser;

            
        }

        public User GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[tblUsers] where UserId={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new User(
                                       int.Parse(dataReader["UserId"].ToString()),
                                       dataReader["UserLogin"].ToString(),
                                       dataReader["UserPassword"].ToString(),
                                       dataReader["UserName"].ToString(),
                                       int.Parse(dataReader["UserRoleid"].ToString())
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[tblUsers] where UserId={0}", key);

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

        public bool Change(User entity)
        {

            var command = _con.CreateCommand();
            command.CommandText = string.Format("update tblUsers " +
                "set UserLogin='{0}', UserPassword='{1}', UserName='{2}', UserRoleId={3}  where UserId = {4}"
                , entity.UserLogin, entity.UserPassword, entity.UserName, entity.UserRoleId,  entity.UserId);
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

        public bool Add(User entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[tblUsers] (UserLogin,UserPassword,UserName,UserRoleId)  " +
                "VALUES( '{0}', '{1}', '{2}', {3})",
                entity.UserLogin, entity.UserPassword, entity.UserName, entity.UserRoleId
                );
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
