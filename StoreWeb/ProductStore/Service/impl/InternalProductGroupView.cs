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
    class InternalProductGroupView:IProductGroupView
    {
        private readonly IRepositoryFactory _sourceFactory;

       
        public InternalProductGroupView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<ProductGroupViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductGroup, int>())
            {
                IEnumerable<ProductCategory> categories = _sourceFactory.CreateRepository<Entity.ProductCategory, int>().GetAll();
                return repository.GetAll().Select(c => new ProductGroupViewModel(c.GroupId, c.GroupName, c.GroupDescription, c.CategoryId,

                  categories.Where(ct => ct.CategoryId == c.CategoryId).Select(cat => new ProductCategoryViewModel(cat.CategoryId, cat.CategoryName, cat.CategoryDescription)).FirstOrDefault()));  
                       
            }
        }

        public ProductGroupViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductGroup, int>())
            {
                var group = repository.GetSingle(id);
                return new ProductGroupViewModel(group.GroupId, group.GroupName, group.GroupDescription, group.CategoryId);
            }
        }

        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductGroup, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(ProductGroupViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductGroup, int>())
            {
                

                return repository.Add(new ProductGroup(entity.GroupId, entity.GroupName, entity.GroupDescription, entity.CategoryId));

            };
        }

        public bool Change(ProductGroupViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.ProductGroup, int>())
            {
                return repository.Change(new ProductGroup(entity.GroupId, entity.GroupName, entity.GroupDescription, entity.CategoryId));
            }
        }

        public bool CanDelete(int Groupid, out string reason)
        {
            reason = null;
            using (var repository = _sourceFactory.CreateRepository<Entity.Product, int>())
            {
                if (repository.GetAll().Where(c => c.GroupId == Groupid).Any())
                {
                    reason = "You can't delete current group.Group include products!!!";
                    return false;
                }
               return true;
            }
        }
    }
}
