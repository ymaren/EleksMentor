namespace Core.Dal.AdoNet.Repositories
{
    using Store.Logic.Entity;
    using System;
    using System.Data;

    internal class ProductRepository : BaseRepository<Product>
    {

        public ProductRepository(IDbConnection connection) 
            : base(connection, "dbo.Products") { }

        public override bool Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
