namespace Store.Web.App.Controllers
{
    using Models;
    using System.Web.Mvc;
    using System.Web.Security;

    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                string result = "Вы не авторизованы";
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                       if (HttpContext.User.IsInRole("Admin"))
                        return RedirectToAction("Menu", "Home");
                       else
                       return RedirectToAction("Index", "Cart");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        private bool ValidateUser(string login, string password)
        {
            bool isValid = false;

          
            return isValid;
        }
    }
}