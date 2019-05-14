namespace Store.Logic.ProductStore.Service.impl
{
    using Core.Common.Dal;
    using Models.ModifyModels;
    using Models.ViewModels;
    using Service.ModifyServices;
    using Service.ViewServices;
    using System.Collections.Generic;

    internal class ProductGroupServiceImpl : IProductGroupViewService, IProductGroupModifyService
    {
        private readonly IRepositoryFactory _sourceFactory;

        public ProductGroupServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public bool Add(ProductGroupModifyModel entity)
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

        public bool Update(int id, ProductGroupModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductGroupViewModel> ViewAll()
        {
            throw new System.NotImplementedException();
        }

        public ProductGroupViewModel ViewSingle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
