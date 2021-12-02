using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Areas.NVClient.Controllers
{
    public class LuongsNVController : Controller
    {
        private QuanLyNhanSuDbContext db = new QuanLyNhanSuDbContext();

        // GET: NVClient/LuongsNV
        public ActionResult Index( string searchString)
        {
            var links = from l in db.luongs // lấy toàn bộ liên kết
                        select l;
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.NhanViens.NameNhanVien.Contains(searchString)); //lọc theo chuỗi tìm kiếm                
            }
            var luongs = db.luongs.Include(l => l.NhanViens);
            return View(links);
        }

        // GET: NVClient/LuongsNV/Details/5
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

        // GET: NVClient/LuongsNV/Create
        public ActionResult Create()
        {
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "NameNhanVien");
            return View();
        }

        // POST: NVClient/LuongsNV/Create
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

            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "NameNhanVien", luong.IDNhanVien);
            return View(luong);
        }

        // GET: NVClient/LuongsNV/Edit/5
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
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "NameNhanVien", luong.IDNhanVien);
            return View(luong);
        }

        // POST: NVClient/LuongsNV/Edit/5
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
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "NameNhanVien", luong.IDNhanVien);
            return View(luong);
        }

        // GET: NVClient/LuongsNV/Delete/5
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

        // POST: NVClient/LuongsNV/Delete/5
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
