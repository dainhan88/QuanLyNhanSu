﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Areas.Admins.Controllers
{
    public class LuongsController : Controller
    {
        private QuanLyNhanSuDbContext db = new QuanLyNhanSuDbContext();

        // GET: Admins/Luongs
        public ActionResult Index( string searchString)
        {
            var links = from l in db.luongs // lấy toàn bộ liên kết
                        select l;
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.IDNhanVien.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            var luongs = db.luongs.Include(l => l.NhanViens);
            return View(links);
        }

        // GET: Admins/Luongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            return View(luong);
        }

        // GET: Admins/Luongs/Create
        public ActionResult Create()
        {
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "IDNhanVien");
            return View();
        }

        // POST: Admins/Luongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Thang,IDNhanVien,LuongNgay,NgayCong")] Luong luong)
        {
            if (ModelState.IsValid)
            {
                db.luongs.Add(luong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "IDNhanVien", luong.IDNhanVien);
            return View(luong);
        }

        // GET: Admins/Luongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "IDNhanVien", luong.IDNhanVien);
            return View(luong);
        }

        // POST: Admins/Luongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Thang,IDNhanVien,LuongNgay,NgayCong")] Luong luong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "IDNhanVien", luong.IDNhanVien);
            return View(luong);
        }

        // GET: Admins/Luongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            return View(luong);
        }

        // POST: Admins/Luongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Luong luong = db.luongs.Find(id);
            db.luongs.Remove(luong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
