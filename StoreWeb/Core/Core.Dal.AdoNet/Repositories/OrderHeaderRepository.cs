namespace Core.Dal.AdoNet.Repositories
{
    using Store.Logic.Entity;
    using System;
    using System.Data;

    internal class OrderHeaderRepository : BaseRepository<OrderHeader>
    {
        public OrderHeaderRepository(IDbConnection connection)
            : base(connection, "dbo.OrderHeaders") { }

        public override bool Add(OrderHeader entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}
