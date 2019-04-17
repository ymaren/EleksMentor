using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderH
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int OrderToUser { get; set; }
        public int OrderTypeid { get; set; }
        public double OrderAmount { get; set; }


        public OrderH( int orderTypeId, DateTime OrderDate, string orderNumber , int ordertoUser, int orderTypeid, double orderAmount)
        {
            this.OrderId = orderTypeId;
            this.OrderDate = OrderDate;
            this.OrderNumber = orderNumber;
            this.OrderToUser = ordertoUser;
            this.OrderTypeid = orderTypeid;
            this.OrderAmount = orderAmount;
        }
        public OrderH()
        {

        }
    }
}
