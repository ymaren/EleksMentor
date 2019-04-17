using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IProductView:IObject
    {
        ProductViewModel ViewSingle(int id);
        IEnumerable<ProductViewModel> ViewAll();
        bool Add(ProductViewModel entity);
        bool Change(ProductViewModel entity);

        bool Delete(int key);
    }
}
