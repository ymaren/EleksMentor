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
    class InternalUsersRoleCredentialView:IUsersRoleCredentialView
    {
        private readonly IRepositoryFactory _sourceFactory;

       
        public InternalUsersRoleCredentialView(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public List<UsersRoleCredentialViewModel> ViewAll()
        {
            using (var repository = _sourceFactory.CreateRepository<Entity.UsersRoleCredential, int>())
            {
              IEnumerable< UsersRoleCredential> listRoleCred =  _sourceFactory.CreateRepository<Entity.UsersRoleCredential, int>().GetAll();
              IEnumerable<UsersCredential> listCred = _sourceFactory.CreateRepository<Entity.UsersCredential, int>().GetAll();


                

              var query = from allCred in listCred
                            join RoleCred in listRoleCred
                            on allCred.idCredential equals RoleCred.Credentialid
                            into temp
                            from RoleCred in temp.DefaultIfEmpty()
                            select new
                            {
                                
                                UserRoleid = RoleCred!=null? RoleCred.UserRoleid: temp.Intersect,
                                Credentialid = allCred!=null? allCred.idCredential: RoleCred.Credentialid,
                                NameCredential = allCred.NameCredential,
                                FullNameCredential = allCred.FullNameCredential,
                                ParentCredentialid = allCred.ParentCredentialid,
                                Order = allCred.Order,
                                IsSelected = RoleCred != null ? true : false

                            }; 


                //List<UsersRoleCredentialViewModel> result =
                //listRoleCred.Join(listCred, rolcred => rolcred.Credentialid, cred => cred.idCredential, (rolcred, cred) => new { rolcred, cred }).
                //Select(r => new UsersRoleCredentialViewModel(r.rolcred.UserRoleid, r.rolcred.Credentialid,
                //r.cred.NameCredential, r.cred.FullNameCredential, r.cred.ParentCredentialid, r.cred.Order,false)).ToList();

             return query.Select(r => new UsersRoleCredentialViewModel(r.UserRoleid, r.Credentialid,
               r.NameCredential, r.FullNameCredential, r.ParentCredentialid, r.Order, false)).ToList();
            }
        }

        public List<UsersRoleCredentialViewModel> ViewCredentialForRole(int role_id)
        {
           return ViewAll().Where(r => r.UserRoleid == role_id).ToList();
        }

        

       


    }
}
