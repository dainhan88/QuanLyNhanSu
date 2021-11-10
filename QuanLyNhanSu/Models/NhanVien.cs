using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class NhanVien
    {
        [Key]
        [Display(Name = "Mã Số")]
        public String IDNhanVien { get; set; }


        [Required(ErrorMessage = "Họ Và Tên Nhân Viên không được để trống !!!")]
        [Display(Name = "Họ Và Tên")]
        public String NameNhanVien { get; set; }


        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh Nhân Viên không được để trống !!!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinhNV { get; set; }


        [Display(Name = "Số Điện Thoại")]
        public String SDTNhanVienName { get; set; }


        [Display(Name = "GIới Tính")]
        public String GioiTinhNhanVien { get; set; }


        [Display(Name = "Địa Chỉ")]
        public String DiaChiNhanVien { get; set; }


        [Display(Name = "Số căn cước")]
        public String CCCDNhanVien { get; set; }

        [Display(Name = "Ảnh")]

        public string NhanVienImgName { get; set; }
        [NotMapped]
        public HttpPostedFileBase NhanVienImgFile { get; set; }

        [Display(Name = "Mã chức vụ")]
        public string MaChucVu { get; set; }
        [ForeignKey("MaChucVu")]
        public virtual ChucVu ChucVus { get; set; }

        [Display(Name = "Mã Phòng Ban")]
        public string MaPhongBan { get; set; }
        [ForeignKey("MaPhongBan")]
        public virtual PhongBan PhongBans { get; set; }
        public NhanVien()
            {
            NhanVienImgName = "~/Images/Avt.png";
            }
    }
}