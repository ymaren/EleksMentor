namespace Store.Logic.ProductStore.Models.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; internal set; }

        public int HeaderId { get; internal set; }

        public int ProductId { get; internal set; }

        public int OrderQTY { get; internal set; }

        public double ProductPrice { get; internal set; }

        public double ProductSum { get; internal set; }
    }
}
