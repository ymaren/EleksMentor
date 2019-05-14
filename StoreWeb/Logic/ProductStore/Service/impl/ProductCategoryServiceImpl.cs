namespace Store.Logic.ProductStore.Service.impl
{
    using Core.Common.Dal;
    using Entity;
    using Models.ModifyModels;
    using Models.ViewModels;
    using Service.ModifyServices;
    using Service.ViewServices;
    using System.Collections.Generic;
    using System.Linq;

    internal class ProductCategoryServiceImpl : IProductCategoryViewService, IProductCategoryModifyService
    {
        private readonly IRepositoryFactory _sourceFactory;

        public ProductCategoryServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public bool Add(ProductCategoryModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key, out string reason)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, ProductCategoryModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductCategoryViewModel> ViewAll()
        {
            throw new System.NotImplementedException();
        }

        public ProductCategoryViewModel ViewSingle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
