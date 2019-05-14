namespace Core.Dal.AdoNet.Repositories
{
    using Store.Logic.Entity;
    using System;
    using System.Data;

    internal class OrderTypeRepository : BaseRepository<OrderType>
    {
        public OrderTypeRepository(IDbConnection connection) 
            : base(connection, "dbo.OrderTypes") { }

        public override bool Add(OrderType entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(OrderType entity)
        {
            throw new NotImplementedException();
        }
    }
}
