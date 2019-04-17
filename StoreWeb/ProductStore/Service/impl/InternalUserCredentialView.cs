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
    class InternalUserCredentialView:IUserCredentionalView
    {
        private readonly IRepositoryFactory _sourceFactory;

       
        public InternalUserCredentialView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<UserCredentialViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersCredential, int>())
            {
                
              return repository.GetAll().Select(c => new UserCredentialViewModel(c.idCredential, c.NameCredential, c.FullNameCredential, c.ParentCredentialid, c.Order, c.Url));
             }
        }

        public UserCredentialViewModel ViewSingle(int id)
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersCredential, int>() )
            {
                var cred = repository.GetSingle(id);
                return new UserCredentialViewModel(cred.idCredential, cred.NameCredential, cred.FullNameCredential, cred.ParentCredentialid, cred.Order, cred.Url);
                
            }
        }

       
    }
}
