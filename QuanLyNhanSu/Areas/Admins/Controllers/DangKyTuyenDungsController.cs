using System;
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
    public class DangKyTuyenDungsController : Controller
    {
        private QuanLyNhanSuDbContext db = new QuanLyNhanSuDbContext();

        // GET: DangKyTuyenDungs
        public ActionResult Index()
        {
            return View(db.DangKyTuyenDungs.ToList());
        }

        // GET: DangKyTuyenDungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyTuyenDung dangKyTuyenDung = db.DangKyTuyenDungs.Find(id);
            if (dangKyTuyenDung == null)
            {
                return HttpNotFound();
            }
            return View(dangKyTuyenDung);
        }

        // GET: DangKyTuyenDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DangKyTuyenDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,SDT,GioiTinh,NgaySinh,TrinhDoHocVan,DiaChi,Gmail,ViTriUngTuyen,KinhNghiem")] DangKyTuyenDung dangKyTuyenDung)
        {
            if (ModelState.IsValid)
            {
                db.DangKyTuyenDungs.Add(dangKyTuyenDung);
                db.SaveChanges();
                return RedirectToAction("Index","ThanhCong");
            }

            return View(dangKyTuyenDung);
        }

        // GET: DangKyTuyenDungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyTuyenDung dangKyTuyenDung = db.DangKyTuyenDungs.Find(id);
            if (dangKyTuyenDung == null)
            {
                return HttpNotFound();
            }
            return View(dangKyTuyenDung);
        }

        // POST: DangKyTuyenDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SDT,GioiTinh,NgaySinh,TrinhDoHocVan,DiaChi,Gmail,ViTriUngTuyen,KinhNghiem")] DangKyTuyenDung dangKyTuyenDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dangKyTuyenDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dangKyTuyenDung);
        }

        // GET: DangKyTuyenDungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DangKyTuyenDung dangKyTuyenDung = db.DangKyTuyenDungs.Find(id);
            if (dangKyTuyenDung == null)
            {
                return HttpNotFound();
            }
            return View(dangKyTuyenDung);
        }

        // POST: DangKyTuyenDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DangKyTuyenDung dangKyTuyenDung = db.DangKyTuyenDungs.Find(id);
            db.DangKyTuyenDungs.Remove(dangKyTuyenDung);
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
