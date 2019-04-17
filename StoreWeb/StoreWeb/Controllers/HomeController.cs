using ProductStore.Model;
using StoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ProductStore.Models.DbContect;

namespace StoreWeb.Controllers
{
    public class HomeController : Controller
    {
        DBContext _db;

        public HomeController ()
        {
            _db = new DBContext();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Menu()
        {
            List<UserCredentialViewModel> menuItems = _db.UserCredantials.ViewAll().ToList();

            return PartialView(menuItems);
        }


    }
}