using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.Model;
using Core.Dal;
using Entity;

namespace ProductStore.Service.impl
{
    class InternalOrderDView : IOrderDView
    {
        private readonly IRepositoryFactory _sourceFactory;


        public InternalOrderDView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<OrderDViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderD, int>())
            {
               
                IEnumerable<OrderDViewModel> list = repository.GetAll().
                    Select(c => new OrderDViewModel (c.OrderDid, c.OrderHid, c.Productid, c.OrderQTY, c.ProductPrice, c.ProductSum));
                return list;
            }
        }

        public OrderDViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderD, int>())
            {

                var orderD = repository.GetSingle(id);
                
                return new OrderDViewModel(orderD.OrderDid, orderD.OrderHid, orderD.Productid, orderD.OrderQTY, orderD.ProductPrice, orderD.ProductSum);
            }
        }

        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderD, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(OrderDViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderD, int>())
            {

                return repository.Add(new OrderD(entity.OrderDid, entity.OrderHid, entity.Productid, entity.OrderQTY,  entity.ProductPrice, entity.ProductSum));

            };

        }

        public bool Change(OrderDViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderD, int>())
            {

                return repository.Change(new OrderD(entity.OrderDid, entity.OrderHid, entity.Productid, entity.OrderQTY, entity.ProductPrice, entity.ProductSum));

            }
        }


    }
}
