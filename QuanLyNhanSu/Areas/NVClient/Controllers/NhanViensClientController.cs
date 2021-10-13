using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Areas.NVClient.Controllers
{
    [Authorize(Roles ="client")]
    public class NhanViensClientController : Controller
    {
        private QuanLyNhanSuDbContext db = new QuanLyNhanSuDbContext();

        // GET: NVClient/NhanViensClient
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.ChucVus).Include(n => n.PhongBans);
            return View(nhanViens.ToList());
        }

        // GET: NVClient/NhanViensClient/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NVClient/NhanViensClient/Create
        public ActionResult Create()
        {
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan");
            return View();
        }

        // POST: NVClient/NhanViensClient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "IDNhanVien,NameNhanVien,NgaySinhNV,SDTNhanVienName,GioiTinhNhanVien,DiaChiNhanVien,CCCDNhanVien,MaChucVu,MaPhongBan")]*/ NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(nhanVien.NhanVienImgFile.FileName);
                string extension = Path.GetExtension(nhanVien.NhanVienImgFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                nhanVien.NhanVienImgName = "/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                nhanVien.NhanVienImgFile.SaveAs(fileName);
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nhanVien.MaPhongBan);
            return View(nhanVien);
        }
        // GET: NVClient/NhanViensClient/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nhanVien.MaPhongBan);
            return View(nhanVien);
        }

        // POST: NVClient/NhanViensClient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNhanVien,NameNhanVien,NgaySinhNV,SDTNhanVienName,GioiTinhNhanVien,DiaChiNhanVien,CCCDNhanVien,MaChucVu,MaPhongBan")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nhanVien.MaPhongBan);
            return View(nhanVien);
        }

        // GET: NVClient/NhanViensClient/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NVClient/NhanViensClient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
