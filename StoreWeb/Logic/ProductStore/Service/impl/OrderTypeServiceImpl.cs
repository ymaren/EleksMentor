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

    internal class OrderTypeServiceImpl : IOrderTypeViewService, IOrderTypeModifyService
    {
        private readonly IRepositoryFactory _sourceFactory;


        public OrderTypeServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public bool Add(OrderTypeModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int id, OrderTypeModifyModel entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OrderTypeViewModel> ViewAll()
        {
            throw new System.NotImplementedException();
        }

        public OrderTypeViewModel ViewSingle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
