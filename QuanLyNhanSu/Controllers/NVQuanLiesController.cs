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

namespace QuanLyNhanSu.Controllers
{
    public class NVQuanLiesController : Controller
    {
        private QuanLyNhanSuDbContext db = new QuanLyNhanSuDbContext();
        AutoGenerateKey auto = new AutoGenerateKey();
        // GET: NVQuanLies
        public ActionResult Index()
        {
            var nhanViens = db.NVQuanLys.Include(n => n.ChucVus).Include(n => n.PhongBans);
            return View(nhanViens.ToList());
        }

        // GET: NVQuanLies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVQuanLy nVQuanLy = db.NVQuanLys.Find(id);
            if (nVQuanLy == null)
            {
                return HttpNotFound();
            }
            return View(nVQuanLy);
        }

        // GET: NVQuanLies/Create
        public ActionResult Create()
        {
            var QLID = db.NhanViens.OrderByDescending(m => m.IDNhanVien).FirstOrDefault().IDNhanVien;
            var newID = auto.GenerateKey("QL", QLID);
            ViewBag.NewNVID = newID;
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan");
            return View();
        }

        // POST: NVQuanLies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "IDNhanVien,NameNhanVien,NgaySinhNV,SDTNhanVienName,GioiTinhNhanVien,DiaChiNhanVien,CCCDNhanVien,NhanVienImgName,MaChucVu,MaPhongBan,Note")]*/ NVQuanLy nVQuanLy)
        {
            if (ModelState.IsValid)
            {
                //string fileName = Path.GetFileNameWithoutExtension(nVQuanLy.NhanVienImgFile.FileName);
                //string extension = Path.GetExtension(nVQuanLy.NhanVienImgFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //nVQuanLy.NhanVienImgName = "/Images/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                //nVQuanLy.NhanVienImgFile.SaveAs(fileName);
                db.NhanViens.Add(nVQuanLy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nVQuanLy.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nVQuanLy.MaPhongBan);
            return View(nVQuanLy);
        }

        // GET: NVQuanLies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVQuanLy nVQuanLy = db.NVQuanLys.Find(id);
            if (nVQuanLy == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nVQuanLy.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nVQuanLy.MaPhongBan);
            return View(nVQuanLy);
        }

        // POST: NVQuanLies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNhanVien,NameNhanVien,NgaySinhNV,SDTNhanVienName,GioiTinhNhanVien,DiaChiNhanVien,CCCDNhanVien,NhanVienImgName,MaChucVu,MaPhongBan,Note")] NVQuanLy nVQuanLy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nVQuanLy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nVQuanLy.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nVQuanLy.MaPhongBan);
            return View(nVQuanLy);
        }

        // GET: NVQuanLies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVQuanLy nVQuanLy = db.NVQuanLys.Find(id);
            if (nVQuanLy == null)
            {
                return HttpNotFound();
            }
            return View(nVQuanLy);
        }

        // POST: NVQuanLies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NVQuanLy nVQuanLy = db.NVQuanLys.Find(id);
            db.NhanViens.Remove(nVQuanLy);
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
