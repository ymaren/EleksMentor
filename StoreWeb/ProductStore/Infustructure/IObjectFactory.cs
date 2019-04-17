namespace ProductStore.Infustructure
{
    public interface IObjectFactory
    {
        TObject Creates<TObject>() where TObject : IObject;
    }
}
