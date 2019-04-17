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
    class InternalOrderTypeView: IOrderTypeView
    {
        private readonly IRepositoryFactory _sourceFactory;

       
        public InternalOrderTypeView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<OrderTypeViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderType, int>())
            {
              return repository.GetAll().Select(c => new OrderTypeViewModel(c.OrderTypeId, c.OrderTypeName));
            }
        }

        public OrderTypeViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderType, int>() )
            {
               var orderType = repository.GetSingle(id);
               return new OrderTypeViewModel(orderType.OrderTypeId, orderType.OrderTypeName);
            }
        }

        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderH, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(OrderTypeViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderType, int>())
            {

               return repository.Add(new OrderType(entity.OrderTypeId, entity.OrderTypeName));
                 
            };
           
        }

        public bool Change(OrderTypeViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderType, int>())
            {

                return repository.Change(new OrderType(entity.OrderTypeId, entity.OrderTypeName));

            }
        }

        
    }
}
