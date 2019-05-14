namespace Core.Dal.AdoNet.Repositories
{
    using Store.Logic.Entity;
    using System;
    using System.Data;

    internal class ProductCategoryRepository : BaseRepository<ProductCategory>
    {
        public ProductCategoryRepository(IDbConnection connection) 
            : base(connection, "dbo.ProductCategories") { }

        public override bool Add(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(ProductCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
