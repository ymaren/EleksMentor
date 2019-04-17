using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetUserRoleCredentialRepository: IGenericRepository<UsersRoleCredential, int>
    {
        private readonly IDbConnection _con;
        public AdoNetUserRoleCredentialRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
        }
               
        public IEnumerable<UsersRoleCredential> GetAll()
        {
            List<UsersRoleCredential> listUserRoleCredential;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[UserRoleCredential]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listUserRoleCredential = new List<UsersRoleCredential> { };


                    while (dataReader.Read())
                    {
                        listUserRoleCredential.Add
                              (
                              new UsersRoleCredential(
                             int.Parse(dataReader["UserRoleid"].ToString()),
                             int.Parse(dataReader["Credentialid"].ToString())
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
            return listUserRoleCredential;

            
        }

        public UsersRoleCredential GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[UserRoleCredential] where UserRoleid={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new UsersRoleCredential(
                                       int.Parse(dataReader["UserRoleid"].ToString()),
                                       int.Parse(dataReader["Credentialid"].ToString())
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[UserRoleCredential] where UserRoleid={0}", key);

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

        public bool Change(UsersRoleCredential entity)
        {

            //var command = _con.CreateCommand();
            //command.CommandText = string.Format("update dicUsersRoles " +
            //    "set UserRoleName='{0}' where UserRoleId={1}"
            //    , entity.UserRoleName, entity.UserRoleId);
            //try
            //{
            //    if (command.ExecuteNonQuery() == 1)
            //    {

            //        return true;
            //    }
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}
            return false;
        }

        public bool Add(UsersRoleCredential entity)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("INSERT INTO [dbo].[UserRoleCredential] (UserRoleid , Credentialid)  " +
                "VALUES( '{0}' {1})",
                entity.UserRoleid, entity.Credentialid);
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
