using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IOrderTypeView:IObject
    {
        OrderTypeViewModel ViewSingle(int id);
              
        IEnumerable<OrderTypeViewModel> ViewAll();
        bool Add(OrderTypeViewModel entity);

        bool Change(OrderTypeViewModel entity);

        bool Delete(int key);
    }
}
