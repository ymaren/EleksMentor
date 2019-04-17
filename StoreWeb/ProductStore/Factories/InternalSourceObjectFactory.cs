using Core.Dal;

using ProductStore.Infustructure;
using ProductStore.Service;
using ProductStore.Service.impl;
using System;
using System.Collections.Generic;

namespace ProductStore.Factories
{
    internal class InternalSourceObjectFactory : IObjectFactory
    {
        private readonly IRepositoryFactory _sourceFactory;

        public InternalSourceObjectFactory(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        private readonly static Dictionary<Type, Func<IRepositoryFactory, IObject>> _supportedObjects = new Dictionary<Type, Func<IRepositoryFactory, IObject>>
        {
            [typeof(IProductView)] = (factory)    => new InternalProductView(factory),
            [typeof(IProductCategoryView)] = (factory) => new InternalProductCategoryView(factory),
            [typeof(IProductGroupView)] = (factory) => new InternalProductGroupView(factory),
            [typeof(IUserView)] = (factory) => new InternalUserView(factory),
            [typeof(IUsersRoleView)] = (factory) => new InternalUsersRoleView(factory),
            [typeof(IUserCredentionalView)] = (factory) => new InternalUserCredentialView(factory),
            [typeof(IOrderTypeView)] = (factory) => new InternalOrderTypeView(factory),
            [typeof(IOrderHView)] = (factory) => new InternalOrderHView(factory)
           
        };
       
        public TObject Creates<TObject>() where TObject : IObject
        {
            Func<IRepositoryFactory, IObject> delegateFactory = null;
            if (_supportedObjects.TryGetValue(typeof(TObject), out  delegateFactory))
            {
                return (TObject)delegateFactory(_sourceFactory);
            }

            throw new System.NotImplementedException();
        }
    }
}
