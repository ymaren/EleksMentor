namespace Core.Dal.AdoNet.Repositories
{
    using Store.Logic.Entity;
    using System;
    using System.Data;

    internal class UserRepository : BaseRepository<User>
    {

        public UserRepository(IDbConnection connection)
            : base(connection, "dbo.Users") { }

        public override bool Add(User entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
