using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyNhanSu.Areas.Admins.Controllers
{
    public class AccountsADMController : Controller
    {
        // GET: Admins/AccountsADM
        QuanLyNhanSuDbContext db = new QuanLyNhanSuDbContext();
        Encrytion enc = new Encrytion();
        StringProcess strPro = new StringProcess();


        public ActionResult Login(string returnUrl)

        {
            if (CheckSession() == 1)

            {

                return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
            }
            else if (CheckSession() == 2)

            {
                return RedirectToAction("Index", "Home", new { Area = "" });

            }
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(Account acc, string returnUrl)

        {
            try
            {
                if (!string.IsNullOrEmpty(acc.UseName) && !string.IsNullOrEmpty(acc.PassWord))
                {

                    using (var db = new QuanLyNhanSuDbContext())

                    {
                        var passToMD5 = strPro.GetMD5(acc.PassWord);
                        var account = db.Accounts.Where(m => m.UseName.Equals(acc.UseName) && m.PassWord.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UseName, false);
                            Session["idUser"] = acc.UseName;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectTolocal(returnUrl);
                        }

                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");

                    }
                }
                ModelState.AddModelError("", "Username and password is required.");
            }

            catch
            {
                ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                //Mã Hóa mật khẩu trước khi cho vào database
                acc.PassWord = enc.PasswordEncrytion(acc.PassWord);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "AccountsADM");
            }
            return View(acc);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["iduser"] = null;
            return RedirectToAction("Login", "Accounts");
        }
        private ActionResult RedirectTolocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "Home", new { Area = "" });
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private int CheckSession()
        {
            using (var db = new QuanLyNhanSuDbContext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;
                    if (role != null)
                    {
                        if (role.ToString() == "Admin")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "client")
                        {
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }

       
        public ActionResult Change_password_ADM(string id)
        {
            Account acc = db.Accounts.Find(id);
            return View(acc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change_password_ADM(Account acc, FormCollection form)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    acc.PassWord = enc.PasswordEncrytion(form["PassWord"]);
                    db.Entry(acc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
                }
                catch
                {
                    ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác!!");
                }
            }
            ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác!!");
            return View(acc);
        }
    }
}