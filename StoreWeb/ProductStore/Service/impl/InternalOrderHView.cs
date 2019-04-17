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
    class InternalOrderHView : IOrderHView
    {
        private readonly IRepositoryFactory _sourceFactory;


        public InternalOrderHView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<OrderHViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderH, int>())
            {
                var users = _sourceFactory.CreateRepository<Entity.User, int>().GetAll();
                IEnumerable<OrderHViewModel> list = repository.GetAll().
                    Select(c => new OrderHViewModel
                    (
                        c.OrderId, c.OrderDate, c.OrderNumber, c.OrderToUser, c.OrderTypeid, c.OrderAmount,
                        new OrderTypeViewModel(c.OrderTypeid, _sourceFactory.CreateRepository<Entity.OrderType, int>().GetSingle(c.OrderTypeid).OrderTypeName),
                        users.Where(u => u.UserId == c.OrderToUser).Select(u => new UserViewModel(u.UserId, u.UserLogin,  u.UserPassword,u.UserName, u.UserRoleId)).FirstOrDefault(),
                        ViewDetailsofOrder(c.OrderId))

                   );



                return list;
            }
        }

        public OrderHViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderH, int>())
            {

                var orderH = repository.GetSingle(id);
                var user = _sourceFactory.CreateRepository<Entity.User, int>().GetSingle(orderH.OrderToUser); 
                return new OrderHViewModel(orderH.OrderId, orderH.OrderDate, orderH.OrderNumber, orderH.OrderToUser, orderH.OrderTypeid, orderH.OrderAmount,
                    new OrderTypeViewModel(orderH.OrderTypeid,
                     _sourceFactory.CreateRepository<Entity.OrderType, int>().GetSingle(orderH.OrderTypeid).OrderTypeName),
                     new UserViewModel(user.UserId, user.UserLogin, user.UserPassword, user.UserName, user.UserRoleId)
                 );
            }
        }


        public IEnumerable<OrderDViewModel> ViewDetailsofOrder( int idOrderH)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderD, int>())
            {
                IEnumerable<OrderDViewModel> list = repository.GetAll().
                    Select(c => new OrderDViewModel
                    (
                        c.OrderDid, c.OrderHid, c.Productid, c.OrderQTY, c.ProductPrice, c.ProductSum
                   //new OrderTypeViewModel(c.OrderTypeid, _sourceFactory.CreateRepository<Entity.OrderType, int>().GetSingle(c.OrderTypeid).OrderTypeName),
                   //users.Where(u => u.UserId == c.OrderToUser).Select(u => new UserViewModel(u.UserId, u.UserLogin, u.UserPassword, u.UserName, u.UserRoleId)).FirstOrDefault())
                   ));


                
                return list;
            }
        }


        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderH, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(OrderHViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderH, int>())
            {

                if ( repository.Add(new OrderH(entity.OrderId, entity.OrderDate,

                    GenerateOrderNumber(entity.OrderDate)
                    , entity.OrderToUser, entity.OrderTypeid, entity.OrderAmount)))
                {
                    int orderh_id = repository.GetAll().FirstOrDefault(c => c.OrderNumber == entity.OrderNumber).OrderId;
                    var orderDrepository = _sourceFactory.CreateRepository<Entity.OrderD, int>();
                    foreach (var details in entity.OrderDetail)
                    {
                        orderDrepository.Add(new OrderD(details.OrderDid, orderh_id, details.Productid, details.OrderQTY, details.ProductPrice, details.ProductSum));
                    }
                }

            };
            return true;
        }


        private string GenerateOrderNumber(DateTime date)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderH, int>())
            {
                int countOrderToday = repository.GetAll().Where(d => d.OrderDate == date.Date).Count() + 1;
                return DateTime.Now.ToString("ddMMyyyy") + "_" + countOrderToday.ToString();
            }
        }


        public bool Change(OrderHViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.OrderH, int>())
            {

                return repository.Change(new OrderH(entity.OrderId, entity.OrderDate, entity.OrderNumber, entity.OrderToUser, entity.OrderTypeid, entity.OrderAmount));

            }
        }


    }
}
