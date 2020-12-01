using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using System.Web.Security;

namespace BookStore.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        CSDLContext db = new CSDLContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Include = "HoTen, SDT, Email, Password")] User register)
        {
            var check = db.Users.Count();

            User account = new User();
            account.HoTen = register.HoTen;
            account.SDT = register.SDT;
            account.Email = register.Email;
            account.Password = register.Password;

            if (check == 0)
            {
                account.MaQuyen = 1;
            }
            else
            {
                account.MaQuyen = 2;
            }

            db.Users.Add(account);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        //Chức năng và giao diện đăng nhập
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")] User user)
        {
            var accounts = db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (user.Email == accounts.Email && user.Password == accounts.Password)
            {
                user.Email = accounts.Email;
                FormsAuthentication.SetAuthCookie(user.Email, false);
                if (accounts.MaQuyen == 1)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ModelState.AddModelError("Lỗi 1", "Lỗi 2");
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}