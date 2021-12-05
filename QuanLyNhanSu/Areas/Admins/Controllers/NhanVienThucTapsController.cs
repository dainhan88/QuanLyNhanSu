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
    public class NhanVienThucTapsController : Controller
    {
        private QuanLyNhanSuDbContext db = new QuanLyNhanSuDbContext();
        AutoGenerateKey aukey = new AutoGenerateKey();

        // GET: Admins/NhanVienThucTaps
        public ActionResult Index(string searchString)
        {
            var links = from l in db.NhanVienThucTaps // lấy toàn bộ liên kết
                        select l;
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.NameNhanVien.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            var nhanViens = db.NhanVienThucTaps.Include(n => n.ChucVus).Include(n => n.PhongBans);
            return View(links);
        }

        // GET: Admins/NhanVienThucTaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVienThucTap nhanVienThucTap = db.NhanVienThucTaps.Find(id);
            if (nhanVienThucTap == null)
            {
                return HttpNotFound();
            }
            return View(nhanVienThucTap);
        }

        // GET: Admins/NhanVienThucTaps/Create
        public ActionResult Create()
        {
            var NVID = db.NhanViens.OrderByDescending(m => m.IDNhanVien).FirstOrDefault().IDNhanVien;
            var newID = aukey.GenerateKey("TT", NVID);
            ViewBag.NewTTID = newID;
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan");
            return View();
        }

        // POST: Admins/NhanVienThucTaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNhanVien,NameNhanVien,NgaySinhNV,SDTNhanVienName,GioiTinhNhanVien,DiaChiNhanVien,CCCDNhanVien,NhanVienImgName,MaChucVu,MaPhongBan,NgayVao,ThoiGianThucTap")] NhanVienThucTap nhanVienThucTap)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVienThucTap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVienThucTap.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nhanVienThucTap.MaPhongBan);
            return View(nhanVienThucTap);
        }

        // GET: Admins/NhanVienThucTaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVienThucTap nhanVienThucTap = db.NhanVienThucTaps.Find(id);
            if (nhanVienThucTap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVienThucTap.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nhanVienThucTap.MaPhongBan);
            return View(nhanVienThucTap);
        }

        // POST: Admins/NhanVienThucTaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNhanVien,NameNhanVien,NgaySinhNV,SDTNhanVienName,GioiTinhNhanVien,DiaChiNhanVien,CCCDNhanVien,NhanVienImgName,MaChucVu,MaPhongBan,NgayVao,ThoiGianThucTap")] NhanVienThucTap nhanVienThucTap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVienThucTap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVienThucTap.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nhanVienThucTap.MaPhongBan);
            return View(nhanVienThucTap);
        }

        // GET: Admins/NhanVienThucTaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVienThucTap nhanVienThucTap = db.NhanVienThucTaps.Find(id);
            if (nhanVienThucTap == null)
            {
                return HttpNotFound();
            }
            return View(nhanVienThucTap);
        }

        // POST: Admins/NhanVienThucTaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVienThucTap nhanVienThucTap = db.NhanVienThucTaps.Find(id);
            db.NhanViens.Remove(nhanVienThucTap);
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
