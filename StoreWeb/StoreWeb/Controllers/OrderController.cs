using ProductStore.Model;
using StoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductStore.Models.DbContect;

namespace StoreWeb.Controllers
{
    [Authorize (Roles ="Admin")]
    public class OrderController : Controller
    {

        DBContext _db;
        IEnumerable<OrderHViewModel> orders;
        IEnumerable<OrderTypeViewModel> orderTypes;
        IEnumerable<UserViewModel> users;
        public OrderController()
        {
            _db = new DBContext();
            orders = _db.Orders.ViewAll();
            orderTypes = _db.OrderType.ViewAll();
            users = _db.User.ViewAll();


        }

        public ViewResult Index()
        {
            ViewBag.OrderTypes = new SelectList(orderTypes, "OrderTypeId", "OrderTypeName");
            ViewBag.Users = new SelectList(users, "UserId", "UserName");

            return View(orders);
        }

        public ActionResult IndexSearch(DateTime? StartDate, DateTime? FinishDate, int? orderToUser, int? OrderTypeId)
        {
            //ViewBag.Roles = new SelectList(usersRole, "UserRoleId", "UserRoleName");
            var selected_orders = orders.Where(u => orderToUser == null || u.OrderToUser == orderToUser).
                Where(u => OrderTypeId == null || u.OrderTypeid == OrderTypeId).Where
                (d=> StartDate == null || d.OrderDate>=StartDate).Where(
                f => FinishDate == null || f.OrderDate <= FinishDate).OrderBy(o=>o.OrderDate).ThenBy(n=>n.OrderNumber);
            return PartialView(selected_orders);
        }



        [HttpGet]
        public ViewResult Edit(int? OrderId)
        {
            ViewBag.OrderTypes = new SelectList(orderTypes, "OrderTypeid", "OrderTypeName");
            ViewBag.Users = new SelectList(users, "UserId", "UserName");
            OrderHViewModel order = orders.FirstOrDefault(c => c.OrderId == OrderId);
            
            return View(order??new OrderHViewModel(DateTime.Now, GenerateOrderNumber (DateTime.Now)));
        }

        private string GenerateOrderNumber (DateTime date)
        {
          int countOrderToday=  orders.Where(d => d.OrderDate == date.Date).Count()+1;
            return DateTime.Now.ToString("ddMMyyyy") + "_" + countOrderToday.ToString();
        }

        [HttpPost]
        public ActionResult Edit(OrderHViewModel order)
        {

            if (ModelState.IsValid)
            {
                if (orders.Any(c => c.OrderId == order.OrderId))
                {
                    _db.Orders.Change(order);
                    TempData["message"] = string.Format("Order \"{0}\"uploaded", order.OrderNumber);

                }
                else
                {
                    _db.Orders.Add(order);
                    TempData["message"] = string.Format("Order\"{0}\"added", order.OrderNumber);
                }
                return RedirectToAction("Index");
            }
            else
            {

                return View(order);
            }

        }
        [HttpPost]
        public ViewResult Create()
        {
            return View("Edit", new OrderHViewModel());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            string message = string.Empty;
            if (_db.Orders.Delete(Id))
            {
                TempData["message"] = string.Format("Order  was deleted");
            }
            return RedirectToAction("Index");
        }


        public ViewResult CreateOrderFromCart()
        {
            return View("Edit", new OrderHViewModel());
        }
    }

}


