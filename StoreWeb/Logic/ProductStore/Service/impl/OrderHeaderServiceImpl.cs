namespace Store.Logic.ProductStore.Service.impl
{
    using Core.Common.Dal;
    using Models.ModifyModels;
    using Models.ViewModels;
    using ModifyServices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewServices;

    internal class OrderHeaderServiceImpl : IOrderHeaderViewService, IOrderHeaderModifyService
    {
        private readonly IRepositoryFactory _sourceFactory;


        public OrderHeaderServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public bool Add(OrderHeaderModifyModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, OrderHeaderModifyModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeaderViewModel> ViewAll()
        {
            throw new NotImplementedException();
        }

        public OrderHeaderViewModel ViewSingle(int id)
        {
            throw new NotImplementedException();
        }

        private string GenerateOrderNumber(DateTime date)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderHeader, int>())
            {
                int countOrderToday = repository.GetAll().Where(d => d.Date == date.Date).Count() + 1;
                return DateTime.Now.ToString("ddMMyyyy") + "_" + countOrderToday.ToString();
            }
        }
    }
}
