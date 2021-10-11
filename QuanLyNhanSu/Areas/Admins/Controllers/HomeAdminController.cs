using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Areas.Admins.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class HomeAdminController : Controller
    {
        // GET: Admins/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}