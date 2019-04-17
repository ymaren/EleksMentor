﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderD
    {
        public int OrderDid { get; set; }
        public int OrderHid { get; set; }
        public int Productid { get; set; }
        public int OrderQTY { get; set; }
        public double ProductPrice { get; set; }
        public double ProductSum { get; set; }

        
        public OrderD( int orderDid, int orderHid, int productid, int orderQTY, double productPrice, double ProductSum)
        {
            this.OrderDid = orderDid;
            this.OrderHid = orderHid;
            this.Productid = productid;
            this.OrderQTY = orderQTY;
            this.ProductPrice = productPrice;
            this.ProductSum = ProductSum;
        }
        public OrderD()
        {

        }
    }
}
