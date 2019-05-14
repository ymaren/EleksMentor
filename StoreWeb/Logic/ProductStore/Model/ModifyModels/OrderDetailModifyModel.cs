namespace Store.Logic.ProductStore.Models.ModifyModels
{
    public class OrderDetailModifyModel
    {
        public int OrderHeaderId { get; set; }

        public int ProductId { get; set; }

        public int OrderQTY { get; set; }

        public double ProductPrice { get; set; }

        public double ProductSum { get; set; }
    }
}
