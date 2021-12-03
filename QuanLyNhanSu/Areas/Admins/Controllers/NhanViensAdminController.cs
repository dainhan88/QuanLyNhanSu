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

namespace QuanLyNhanSu.Areas.Admins.Controllers
{
    
    public class NhanViensAdminController : Controller
    {
        private QuanLyNhanSuDbContext db = new QuanLyNhanSuDbContext();
        AutoGenerateKey aukey = new AutoGenerateKey();

        // GET: Admins/NhanViensAdmin
        //public ActionResult Index()
        //{
        //    var nhanViens = db.NhanViens.Include(n => n.ChucVus).Include(n => n.PhongBans);
        //    return View(nhanViens.ToList());
        //}
        public ActionResult Index(string searchString)
        {
            var links = from l in db.NhanViens // lấy toàn bộ liên kết
                        select l;
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.NameNhanVien.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            //return View(links);
            var nhanViens = db.NhanViens.Include(n => n.ChucVus).Include(n => n.PhongBans);
            return View(links);
        }

        // GET: Admins/NhanViensAdmin/Details/5
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

        // GET: Admins/NhanViensAdmin/Create
        public ActionResult Create()
        {

            var NVID = db.NhanViens.OrderByDescending(m => m.IDNhanVien).FirstOrDefault().IDNhanVien;
            var newID = aukey.GenerateKey("NV", NVID);
            ViewBag.NewNVID = newID;
            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu");
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan");
            return View();
        }

        // POST: Admins/NhanViensAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "IDNhanVien,NameNhanVien,NgaySinhNV,SDTNhanVienName,GioiTinhNhanVien,DiaChiNhanVien,CCCDNhanVien,MaChucVu,MaPhongBan")]*/ NhanVien nhanVien, HttpPostedFileBase NhanVienImgFile)
        {
            if (ModelState.IsValid)
            {
                string path = uploadimage(NhanVienImgFile);
                nhanVien.NhanVienImgName = path;
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChucVu = new SelectList(db.ChucVus, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewBag.MaPhongBan = new SelectList(db.PhongBans, "MaPhongBan", "TenPhongBan", nhanVien.MaPhongBan);
            return View(nhanVien);
        }

        // GET: Admins/NhanViensAdmin/Edit/5
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

        // POST: Admins/NhanViensAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "IDNhanVien,NameNhanVien,NgaySinhNV,SDTNhanVienName,GioiTinhNhanVien,DiaChiNhanVien,CCCDNhanVien,MaChucVu,MaPhongBan")]*/ NhanVien nhanVien, HttpPostedFileBase NhanVienImgFile)
        {
            string path = uploadimage(NhanVienImgFile);

            // move this here, so it has value before ModelState.IsValid
            nhanVien.NhanVienImgName = path;

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

        // GET: Admins/NhanViensAdmin/Delete/5
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

        // POST: Admins/NhanViensAdmin/Delete/5
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

        public string uploadimage(HttpPostedFileBase NhanVienImgFile)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (NhanVienImgFile != null && NhanVienImgFile.ContentLength > 0)
            {
                string extension = Path.GetExtension(NhanVienImgFile.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        // kết hợp đường dẫn file Images + với random và tên file
                        path = Path.Combine(Server.MapPath("/Images/"), random + Path.GetFileName(NhanVienImgFile.FileName));
                        //Lưu file đúng với đường dẫn vừa tạo ở trên
                        NhanVienImgFile.SaveAs(path);
                        // gán path bằng với đường dẫn file vừa lưu
                        path = "/Images/" + random + Path.GetFileName(NhanVienImgFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Vui lòng chỉ thêm các định dạng jpg ,jpeg or png....'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Vui lòng thêm file'); </script>");
                path = "-1";
            }
            return path;
        }
    }
}
