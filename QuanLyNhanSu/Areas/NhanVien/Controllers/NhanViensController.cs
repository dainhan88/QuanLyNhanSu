﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Areas.NhanVien.Controllers
{
    public class NhanViensController : Controller
    {
        // GET: NhanVien/NhanVien
        public ActionResult Index()
        {
            return View();
        }
    }
}