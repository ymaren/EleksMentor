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
    class InternalProductCategoryView:IProductCategoryView
    {
        private readonly IRepositoryFactory _sourceFactory;
               
        public InternalProductCategoryView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<ProductCategoryViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductCategory, int>())
            {
                return repository.GetAll().Select(c => new ProductCategoryViewModel(c.CategoryId, c.CategoryName, c.CategoryDescription));
            }
        }

        public ProductCategoryViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductCategory, int>())
            {
                var categ = repository.GetSingle(id);
                return new ProductCategoryViewModel(categ.CategoryId, categ.CategoryName, categ.CategoryDescription);
            }
        }

        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductCategory, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(ProductCategoryViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductCategory, int>())
            {

                return repository.Add(new ProductCategory(entity.CategoryId, entity.CategoryName, entity.CategoryDescription));

            };
        }

        public bool Change(ProductCategoryViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductCategory, int>())
            {
                return repository.Change(new ProductCategory(entity.CategoryId, entity.CategoryName, entity.CategoryDescription));
            }
        }

        public bool CanDelete(int CategoryId, out string reason)
        {
            reason = null;
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductGroup, int>())
            {
               if (repository.GetAll().Where (c=>c.CategoryId== CategoryId).Any())
                {
                    reason = "You can't delete current category.Category include groups!!!";
                    return false;
                }
                return true;
            }
        }
    }
}
