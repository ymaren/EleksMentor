namespace Store.Logic.ProductStore.Service.impl
{
    using Core.Common.Dal;
    using Entity;
    using Exceptions;
    using Models.ModifyModels;
    using Models.ViewModels;
    using ModifyServices;
    using System.Collections.Generic;
    using System.Linq;
    using ViewServices;

    internal class OrderDetailServiceImpl : IOrderDetailViewService, IOrderDetailModifyService
    {
        private readonly IRepositoryFactory _sourceFactory;

        public OrderDetailServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<OrderDetailViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<OrderDetail, int>())
            {

                var list = repository.GetAll().
                    Select(c => new OrderDetailViewModel
                    {
                        Id = c.Id,
                        HeaderId = c.OrderHeaderId,
                        ProductId = c.ProductId,
                        OrderQTY = c.OrderQTY,
                        ProductPrice = c.ProductPrice,
                        ProductSum = c.ProductSum
                    });
                return list;
            }
        }

        public OrderDetailViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<OrderDetail, int>())
            {
                var order = repository.GetSingle(id);

                return new OrderDetailViewModel
                {
                    Id = order.Id,
                    HeaderId = order.OrderHeaderId,
                    ProductId = order.ProductId,
                    OrderQTY = order.OrderQTY,
                    ProductPrice = order.ProductPrice,
                    ProductSum = order.ProductSum
                };
            }
        }

        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<OrderDetail, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(OrderDetailModifyModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<OrderDetail, int>())
            {
                return repository.Add(new OrderDetail
                {
                    OrderHeaderId = entity.OrderHeaderId,
                    ProductId = entity.ProductId,
                    ProductPrice = entity.ProductPrice,
                    ProductSum = entity.ProductSum,
                    OrderQTY = entity.OrderQTY
                });

            };

        }

        public bool Update(int id, OrderDetailModifyModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<OrderDetail, int>())
            {
                var order = repository.GetSingle(id);
                if (order == null)
                    throw new NotFoundException();
                //Here logic of updateing existed entity

                return repository.Update(order);
            }
        }
    }
}
