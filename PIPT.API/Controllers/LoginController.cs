using System.Web.Mvc;
using PIPT.API.Models;
using System.Web.Security;

namespace PIPT.API.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            //var result = new AccountProcess().Login(model.UserName, model.Password);
            if (Membership.ValidateUser(model.UserName, model.Password) && ModelState.IsValid)
            {
                //SessionHeper.SetSession(new UserSession() { UserName = model.UserName });
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult ChangePassword(User user, string oldPass, string newPass)
        //{
        //    return View();
        //}

    }
}