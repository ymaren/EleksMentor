using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderType
    {
        public int OrderTypeId { get; set; }
        public string OrderTypeName { get; set; }
       

        public OrderType( int orderTypeId, string orderTypeName )
        {
            this.OrderTypeId = orderTypeId;
            this.OrderTypeName = orderTypeName;
            
            
        }
        public OrderType()
        {

        }
    }
}
