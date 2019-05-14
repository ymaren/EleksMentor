namespace Store.Logic.ProductStore.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OrderHeaderViewModel
    {
        public int Id { get; internal set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; internal set; }

        public string OrderNumber { get; internal set; }

        public double OrderAmount { get; internal set; }

        public OrderTypeViewModel OrderType { get; internal set; }

        public UserViewModel OrderToUser { get; internal set; }

        public IEnumerable<OrderDetailViewModel> OrderDetails { get; internal set; }


    }
}
