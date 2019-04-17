using Core.Dal.Ado.Net;
using ProductStore.Infustructure;
using ProductStore.Model;
using ProductStore.Service;
using StoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ProductStore.Models.DbContect;
namespace StoreWeb.Controllers
{
    public class CartController : Controller
    {
        DBContext _db ;
        Cart cart;
        IEnumerable<ProductViewModel> products;
        public CartController()
        {
            _db = new DBContext();
             products = _db.Products.ViewAll();
             cart = new Cart();
        }

        public RedirectToRouteResult AddToCart(Cart cart, int? Id, string returnUrl)
        {
            
            ProductViewModel prod = products.FirstOrDefault(p => p.Id == Id);

            if (prod != null)
            {
                cart.AddItem(prod, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int? Id, string returnUrl)
        {
            ProductViewModel prod = products.FirstOrDefault(p => p.Id == Id);

            if (prod != null)
            {
                cart.RemoveLine(prod);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

                
        public ViewResult Index(Cart cart, string returnUrl)
        {            

            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }




        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            OrderHViewModel newOrder = new OrderHViewModel(DateTime.Now.Date, "order", 1, 1, cart.Lines.Sum(s => s.Quantity * s.Product.Price));

            newOrder.OrderDetail = cart.Lines.Select(line => new OrderDViewModel(
                 line.Product.Id,
                 line.Quantity,
                 line.Product.Price,
                 line.Quantity * line.Product.Price));

            _db.Orders.Add(newOrder);    
                
            
           return View(new ShippingDetails());
        }

    }
}