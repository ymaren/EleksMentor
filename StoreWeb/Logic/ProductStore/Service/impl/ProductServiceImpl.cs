namespace Store.Logic.ProductStore.Service.impl
{
    using Core.Common.Dal;
    using Entity;
    using Models.ViewModels;
    using Models.ModifyModels;
    using Service.ModifyServices;
    using Service.ViewServices;
    using System.Collections.Generic;
    using System.Linq;

    internal class ProductServiceImpl : IProductViewService, IProductModifyService
    {
        private readonly IRepositoryFactory _sourceFactory;

        public ProductServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public bool Add(ProductModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, ProductModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductViewModel> ViewAll()
        {
            throw new System.NotImplementedException();
        }

        public ProductViewModel ViewSingle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
