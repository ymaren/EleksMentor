namespace Store.Logic.Entity
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderHeaderId { get; set; }

        public int ProductId { get; set; }

        public int OrderQTY { get; set; }

        public double ProductPrice { get; set; }

        public double ProductSum { get; set; }

        public OrderHeader OrderHeader { get; set; }

        public Product Product { get; set; }
    }
}
