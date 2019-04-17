using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Model
{
   public class OrderHViewModel
    {

        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int OrderToUser { get; set; }
        public int OrderTypeid { get; set; }
        public double OrderAmount { get; set; }
        public OrderTypeViewModel OrderType { get; set; }
        public UserViewModel  User { get; set; }
        public IEnumerable<OrderDViewModel> OrderDetail;

        public OrderHViewModel(int orderId, DateTime OrderDate, string orderNumber, int ordertoUser, int OrderTypeid, double orderAmount, OrderTypeViewModel OrderType, UserViewModel user,
            IEnumerable<OrderDViewModel> orderDetail
            )
        {
            this.OrderId = orderId;
            this.OrderDate = OrderDate;
            this.OrderNumber = orderNumber;
            this.OrderToUser = ordertoUser;
            this.OrderTypeid = OrderTypeid;
            this.OrderAmount = orderAmount;
            this.OrderType = OrderType;
            this.User = user;
            this.OrderDetail = orderDetail;

        }



        public OrderHViewModel(int orderId, DateTime OrderDate, string orderNumber, int ordertoUser, int OrderTypeid, double orderAmount, OrderTypeViewModel OrderType, UserViewModel user)
        {
            this.OrderId = orderId;
            this.OrderDate = OrderDate;
            this.OrderNumber = orderNumber;
            this.OrderToUser = ordertoUser;
            this.OrderTypeid = OrderTypeid;
            this.OrderAmount = orderAmount;
            this.OrderType = OrderType;
            this.User = user;

        }

        public OrderHViewModel(int orderId, DateTime OrderDate, string orderNumber, int ordertoUser, int OrderTypeid, double orderAmount)
        {
            this.OrderId = orderId;
            this.OrderDate = OrderDate;
            this.OrderNumber = orderNumber;
            this.OrderToUser = ordertoUser;
            this.OrderTypeid = OrderTypeid;
            this.OrderAmount = orderAmount;
            this.OrderType = null;
        }


        public OrderHViewModel( DateTime OrderDate, string orderNumber, int ordertoUser, int OrderTypeid, double orderAmount)
        {
           
            this.OrderDate = OrderDate;
            this.OrderNumber = orderNumber;
            this.OrderToUser = ordertoUser;
            this.OrderTypeid = OrderTypeid;
            this.OrderAmount = orderAmount;
           

        }


        public OrderHViewModel( DateTime OrderDate, string orderNumber)
        {
            
            this.OrderDate = OrderDate;
            this.OrderNumber = orderNumber;
           
        }


        public OrderHViewModel()
        {

        }
    }
}
