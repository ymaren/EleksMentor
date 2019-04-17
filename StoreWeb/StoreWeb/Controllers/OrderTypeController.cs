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
    public class OrderTypeController : Controller
    {

        DBContext _db;
        IEnumerable<OrderTypeViewModel> orderTypes;
        
        public OrderTypeController()
        {
            _db = new DBContext();
            orderTypes = _db.OrderType.ViewAll();
        }

        //list
        public ViewResult Index()
        {
            return View(orderTypes);
        }

        //edit one group
        [HttpGet]
        public ViewResult Edit(int? OrderTypeId)
        {

            OrderTypeViewModel orderType = orderTypes.FirstOrDefault(c => c.OrderTypeId == OrderTypeId);
            return View(orderType);
        }

        [HttpPost]
        public ActionResult Edit(OrderTypeViewModel orderType)
        {
            
            if (ModelState.IsValid)
            {
                if (orderTypes.Any(c => c.OrderTypeId== orderType.OrderTypeId))
                {
                    _db.OrderType.Change(orderType);
                    TempData["message"] = string.Format("Order type \"{0}\"uploaded", orderType.OrderTypeName);
                    
                }
                else
                {
                    _db.OrderType.Add(orderType);
                    TempData["message"] = string.Format("Order type\"{0}\"added", orderType.OrderTypeName);
                }
               return RedirectToAction("Index");
            }
            else
            {
                
                return View(orderType);
            }
          
        }

        [HttpPost]
        public ViewResult Create()
        {
            return View("Edit", new OrderTypeViewModel());
        }

        //[HttpPost]
        //public ActionResult Delete(int Id)
        //{
        //    string message = string.Empty;
        //    if (!_db.UserRole.CanDelete(Id, out message))
        //    {
        //        TempData["message"] = string.Format(message);
        //        return RedirectToAction("Index");
        //    }
        //    if (_db.UserRole.Delete(Id))
        //    {
        //        TempData["message"] = string.Format("Role  was deleted");
        //    }
        //    return RedirectToAction("Index");
        //}
    }

}


   