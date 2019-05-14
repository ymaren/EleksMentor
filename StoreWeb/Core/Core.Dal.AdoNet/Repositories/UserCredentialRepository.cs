namespace Core.Dal.AdoNet.Repositories
{
    using Store.Logic.Entity;
    using System;
    using System.Data;

    internal class UserCredentialRepository : BaseRepository<UserCredential>
    {
        public UserCredentialRepository(IDbConnection connection)
            : base(connection, "dbo.UserCredentials") { }

        public override bool Add(UserCredential entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(UserCredential entity)
        {
            throw new NotImplementedException();
        }
    }
}
