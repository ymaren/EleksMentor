namespace Store.Logic.ProductStore.Service.impl
{
    using Core.Common.Dal;
    using Models.ViewModels;
    using Service.ViewServices;
    using System.Collections.Generic;

    internal class UserCredentialServiceImpl : IUserCredentionalView
    {
        private readonly IRepositoryFactory _sourceFactory;

        public UserCredentialServiceImpl(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IEnumerable<UserCredentialViewModel> ViewAll()
        {
            throw new System.NotImplementedException();
        }

        public UserCredentialViewModel ViewSingle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
