using ProductStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Service
{
    public interface IProductCategoryView : IObject
    {
        ProductCategoryViewModel ViewSingle(int id);
        IEnumerable<ProductCategoryViewModel> ViewAll();
        bool Add(ProductCategoryViewModel entity);
        bool Change(ProductCategoryViewModel entity);
        bool CanDelete(int key, out string reason);
        bool Delete(int key);
    }
}
