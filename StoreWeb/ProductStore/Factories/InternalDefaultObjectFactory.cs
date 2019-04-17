
using ProductStore.Infustructure;
using ProductStore.Service;
using ProductStore.Service.impl;

using System;
using System.Collections.Generic;

namespace ProductStore.Factories
{
    internal class InternalDefaultObjectFactory : IObjectFactory
    {
        private readonly static Dictionary<Type, Func<IObject>> _supportedObjects = new Dictionary<Type, Func<IObject>>
        {
            //[typeof(IProductView)] = () => new InternalProductView()

        };

        public TObject Creates<TObject>() where TObject : IObject
        {
            Func<IObject> delegateFactory = null;
            if (_supportedObjects.TryGetValue(typeof(TObject), out  delegateFactory))
            {
                return (TObject)delegateFactory();
            }

            throw new System.NotImplementedException();
        }
    }
}
