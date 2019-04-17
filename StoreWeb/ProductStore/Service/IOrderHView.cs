using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IOrderHView:IObject
    {
        OrderHViewModel ViewSingle(int id);
              
        IEnumerable<OrderHViewModel> ViewAll();
        bool Add(OrderHViewModel entity);

        bool Change(OrderHViewModel entity);

        bool Delete(int key);
    }
}
