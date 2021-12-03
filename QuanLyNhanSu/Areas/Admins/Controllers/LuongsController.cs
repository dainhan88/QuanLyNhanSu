using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
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
        //public ActionResult Upfile()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Upfile(HttpPostedFileBase file)
        //{
        //    string filePath = string.Empty;
        //    if (file != null)
        //    {
        //        string path = Server.MapPath("~/Uploads/");

        //        filePath = path + Path.GetFileName(file.FileName);
        //        string extension = Path.GetExtension(file.FileName);
        //        file.SaveAs(filePath);

        //        string conString = string.Empty;

        //        switch (extension)
        //        {
        //            case ".xls": //Excel 97-03.
        //                conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
        //                break;
        //            case ".xlsx": //Excel 07 and above.
        //                conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
        //                //conString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'";
        //                break;
        //        }

        //        DataTable dt = new DataTable();
        //        conString = string.Format(conString, filePath);

        //        using (OleDbConnection connExcel = new OleDbConnection(conString))
        //        {
        //            using (OleDbCommand cmdExcel = new OleDbCommand())
        //            {
        //                using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
        //                {
        //                    cmdExcel.Connection = connExcel;

        //                    //Get the name of First Sheet.
        //                    connExcel.Open();
        //                    DataTable dtExcelSchema;
        //                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //                    string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        //                    connExcel.Close();

        //                    //Read Data from First Sheet.
        //                    connExcel.Open();
        //                    cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
        //                    odaExcel.SelectCommand = cmdExcel;
        //                    odaExcel.Fill(dt);
        //                    connExcel.Close();
        //                }
        //            }
        //        }

        //        conString = @"data source=DAINHAN\SQLEXPRESS;initial catalog=QuanLyNhanSu;integrated security=True";
        //        using (SqlConnection con = new SqlConnection(conString))
        //        {
        //            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
        //            {
        //                //Set the database table name.
        //                sqlBulkCopy.DestinationTableName = "dbo.Luongs";
        //                sqlBulkCopy.ColumnMappings.Add("Thang", "Thang");
        //                sqlBulkCopy.ColumnMappings.Add("IDNhanVien", "IDNhanVien");                     
        //                sqlBulkCopy.ColumnMappings.Add("LuongNgay", "LuongNgay");
        //                sqlBulkCopy.ColumnMappings.Add("NgayCong", "NgayCong");
        //                con.Open();
        //                sqlBulkCopy.WriteToServer(dt);
        //                con.Close();
        //            }
        //        }
        //    }
        //    //if the code reach here means everthing goes fine and excel data is imported into database
        //    ViewBag.Success = "Thêm dữ liệu thành công";

        //    return RedirectToAction("Index");
        //}
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
