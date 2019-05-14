namespace Core.Dal.AdoNet.Repositories
{
    using Store.Logic.Entity;
    using System;
    using System.Data;

    internal class UserRoleRepository : BaseRepository<Role>
    {
        public UserRoleRepository(IDbConnection connection) 
            : base(connection, "dbo.Roles") { }

        public override bool Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
