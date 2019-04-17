using Core.Dal;
using ProductStore.Factories;

namespace ProductStore.Infustructure
{
    public sealed class ObjectFactoryBuilder
    {
        private IRepositoryFactory _sourceFactory;
        public void AddSource(IRepositoryFactory sourceFactory)
        {
            _sourceFactory = sourceFactory;
        }

        public IObjectFactory Build()
        {
            if (_sourceFactory == null)
                return new InternalDefaultObjectFactory();

            return new InternalSourceObjectFactory(_sourceFactory);
        }
    }
}
