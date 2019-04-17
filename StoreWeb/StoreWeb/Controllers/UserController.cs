using ProductStore.Model;
using StoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStore.Models.DbContect;

namespace StoreWeb.Controllers
{
    public class UserController : Controller
    {

        DBContext _db;
        IEnumerable<UsersRoleViewModel> usersRole;
        public UserController()
        {
            _db = new DBContext();
             usersRole = _db.UserRole.ViewAll();
        }

        // GET: User
        public ActionResult Index()
        {
            ViewBag.Roles = new SelectList(usersRole, "UserRoleId", "UserRoleName");
            var users = _db.User.ViewAll();
            return View(users);
        }
      
        public ActionResult IndexSearch(int? UserRoleId)
        {
            ViewBag.Roles = new SelectList(usersRole, "UserRoleId", "UserRoleName");
            var users = _db.User.ViewAll().Where(u => UserRoleId == null||  u.UserRoleId== UserRoleId);
            return PartialView(users);
        }

      

        public ActionResult CreateChange(int? UserId)
        {
            SelectList roles = new SelectList(_db.UserRole.ViewAll(), "UserRoleId", "UserRoleName");
            ViewBag.Roles = roles;
            UserViewModel user = _db.User.ViewAll().FirstOrDefault(u => u.UserId == UserId);
            return View(user);
        }

        [HttpPost]
        public ActionResult CreateChange(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_db.User.ViewAll().Any(u=>u.UserId== userViewModel.UserId))
                {
                    _db.User.Change(userViewModel);
                    TempData["message"] = string.Format("Изменения в User\"{0}\" были сохранены", userViewModel.UserLogin);

                }
                else
                {
                    _db.User.Add(userViewModel);
                    TempData["message"] = string.Format("добавлен User\"{0}\"", userViewModel.UserLogin);
                }
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(userViewModel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int UserId)
        {
            if (_db.User.Delete(UserId))
            {
                TempData["message"] = string.Format("User  was deleted");
            }
            return RedirectToAction("Index");
        }


}
}