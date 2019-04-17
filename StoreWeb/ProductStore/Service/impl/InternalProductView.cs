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
    class InternalProductView:IProductView
    {
        private readonly IRepositoryFactory _sourceFactory;

       
        public InternalProductView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<ProductViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.Product, int>())
            {
               var grouppository = _sourceFactory.CreateRepository<Entity.ProductGroup, int>();
               IEnumerable<ProductGroup> groups = _sourceFactory.CreateRepository<Entity.ProductGroup, int>().GetAll();

               return repository.GetAll().Select(c => new ProductViewModel(c.Id, c.ProductCode, c.Name, c.Price, c.Description, c.GroupId,

                groups.Where(g => g.GroupId == c.GroupId).Select(gr => new ProductGroupViewModel(gr.GroupId, gr.GroupName, gr.GroupDescription, gr.CategoryId)).FirstOrDefault()));
                           



                  
            }
        }

        public ProductViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.Product, int>() )
            {
                var repositoryGroup = _sourceFactory.CreateRepository<Entity.ProductGroup, int>();

                var lot = repository.GetSingle(id);

                var group = repositoryGroup.GetSingle(lot.GroupId);

                return new ProductViewModel(lot.Id, lot.ProductCode, lot.Name, lot.Price, lot.Description, lot.GroupId, 
                    
                    new ProductGroupViewModel(group.GroupId, group.GroupName, group.GroupDescription,group.CategoryId)
                    );
            }
        }

        public bool Delete(int key)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.Product, int>())
            {
                return repository.Delete(key);
            }
        }

        public bool Add(ProductViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.Product, int>())
            {

               return repository.Add(new Product (entity.Id, entity.ProductCode, entity.Name, entity.Price, entity.Description, entity.GroupId));
                 
            };
           
        }

        public bool Change(ProductViewModel entity)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.Product, int>())
            {

                return repository.Change(new Product(entity.Id, entity.ProductCode, entity.Name, entity.Price, entity.Description, entity.GroupId));

            }
        }
    }
}
