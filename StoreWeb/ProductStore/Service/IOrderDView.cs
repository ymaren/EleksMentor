using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IOrderDView:IObject
    {
        OrderDViewModel ViewSingle(int id);
              
        IEnumerable<OrderDViewModel> ViewAll();
        bool Add(OrderDViewModel entity);

        bool Change(OrderDViewModel entity);

        bool Delete(int key);
    }
}
