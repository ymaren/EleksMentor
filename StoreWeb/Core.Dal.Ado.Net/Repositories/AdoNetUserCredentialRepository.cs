using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Ado.Net.Repositories
{
    class AdoNetUserCredentialRepository : IGenericRepository<UsersCredential, int>
    {
        private readonly IDbConnection _con;
        public AdoNetUserCredentialRepository(IDbConnection connection)
        {
            this._con = connection;
            _con.Open();
        }

        public IEnumerable<UsersCredential> GetAll()
        {
            List<UsersCredential> listUsersCredantial;
            var command = _con.CreateCommand();
            command.CommandText = "SELECT * FROM [LotShop].[dbo].[dicCredential]";
            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    listUsersCredantial = new List<UsersCredential> { };


                    while (dataReader.Read())
                    {
                        UsersCredential u=
                        new UsersCredential(
                              int.Parse(dataReader["idCredential"].ToString()),
                              dataReader["NameCredential"].ToString(),
                              dataReader["FullNameCredential"].ToString(),
                              int.Parse(dataReader["ParentCredentialid"].ToString()),
                              int.Parse(dataReader["Order"].ToString()),
                              dataReader["URL"].ToString());

                        listUsersCredantial.Add
                             (
                              u
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
            return listUsersCredantial;


        }

        public UsersCredential GetSingle(int key)
        {
            var command = _con.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM [LotShop].[dbo].[dicCredential] where idCredential={0}", key);

            try
            {
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return new UsersCredential(
                                       int.Parse(dataReader["idCredential"].ToString()),
                                       dataReader["NameCredential"].ToString(),
                                       dataReader["FullNameCredential"].ToString(),
                                       int.Parse(dataReader["ParentCredentialid"].ToString()),
                                       int.Parse(dataReader["Order"].ToString()),
                                       dataReader["URL"].ToString()
                                       ) ;
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
            command.CommandText = string.Format("delete  [LotShop].[dbo].[dicCredential] where idCredential={0}", key);

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

        public bool Add(UsersCredential entity)
        {
            throw new NotImplementedException();
        }

        public bool Change(UsersCredential entity)
        {
            throw new NotImplementedException();
        }
    }
}
