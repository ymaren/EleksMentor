namespace Core.Dal.AdoNet.Repositories
{
    using Exceptions;
    using Store.Logic.Entity;
    using System;
    using System.Data;

    internal class OrderDetailRepository : BaseRepository<OrderDetail>
    {
        const string IdField = "Id";
        const string ProductIdFild = "ProductId";
        const string OrderHeaderIdFiled = "OrderHeaderId";
        const string OrderQTYField = "OrderQTY";
        const string ProductPriceField = "ProductPrice";
        const string ProductSumField = "ProductSum";

        public OrderDetailRepository(IDbConnection connection)
            : base(connection, "dbo.OrderDetails")
        {
            BindViewMapper(IdField, (o, e) => e.Id = Convert.ToInt32(o));
            BindViewMapper(ProductIdFild, (o, e) => e.ProductId = Convert.ToInt32(o));
            BindViewMapper(OrderHeaderIdFiled, (o, e) => e.OrderHeaderId = Convert.ToInt32(o));
            BindViewMapper(OrderQTYField, (o, e) => e.OrderQTY = Convert.ToInt32(o));
            BindViewMapper(ProductPriceField, (o, e) => e.ProductPrice = Convert.ToDouble(o));
            BindViewMapper(ProductSumField, (o, e) => e.ProductSum = Convert.ToDouble(o));
        }

        
        public override bool Update(OrderDetail entity)
        {
            var command = Connection.CreateCommand();
            command.CommandText = $"update {BaseTable} " +
                $"set {OrderHeaderIdFiled} ='{entity.OrderHeaderId}', " +
                $"{ProductIdFild}='{entity.ProductId}', " +
                $"{OrderQTYField}={entity.OrderQTY}, " +
                $"{ProductPriceField}={entity.ProductPrice}, " +
                $"{ProductSumField}={entity.ProductSum}  where Id={entity.Id}";
            try
            {
                return command.ExecuteNonQuery() == 1;
            }
            catch (Exception e)
            {
                throw new DalExecutionException("", e);
            }
        }

        public override bool Add(OrderDetail entity)
        {
            var command = Connection.CreateCommand();
            command.CommandText = $"insert into {BaseTable} " +
                $"({OrderHeaderIdFiled} ,{ProductIdFild}, {OrderQTYField}, {ProductPriceField}, {ProductSumField}) values " +
                $"('{entity.OrderHeaderId}', '{entity.ProductId}', {entity.OrderQTY}, {entity.ProductPrice}, {entity.ProductSum})";
            try
            {
                return command.ExecuteNonQuery() == 1;
            }
            catch (Exception e)
            {
                throw new DalExecutionException("", e);
            }
        }
    }
}
