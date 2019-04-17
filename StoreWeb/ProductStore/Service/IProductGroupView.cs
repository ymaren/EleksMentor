using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IProductGroupView : IObject
    {
        ProductGroupViewModel ViewSingle(int id);
        IEnumerable<ProductGroupViewModel> ViewAll();
        bool Add(ProductGroupViewModel entity);
        bool Change(ProductGroupViewModel entity);
        bool CanDelete(int key, out string reason);
        bool Delete(int key);
    }
}
