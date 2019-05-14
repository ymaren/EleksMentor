namespace Store.Logic.Entity
{
    using System;
    using System.Collections.Generic;

    public class OrderHeader
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Number { get; set; }

        public int OrderToUserId { get; set; }

        public int TypeId { get; set; }

        public double Amount { get; set; }

        public OrderType Type { get; set; }

        public User OrderToUser { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
