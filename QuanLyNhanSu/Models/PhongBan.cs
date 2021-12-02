using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class PhongBan
    {
        [Key]
        [Display(Name = "Mã Phòng Ban")]
        [Required(ErrorMessage ="Mã Phòng Ban không được để trống !!!")]
        public string MaPhongBan { get; set; }


        [Display(Name = "Tên Phòng Ban")]
        [Required(ErrorMessage = "Tên Phòng Ban không được để trống !!!")]
        public string TenPhongBan { get; set; }


        [Display(Name = "Địa chỉ Phòng Ban")]
        public string DiaChiPhongBan { get; set; }


        [Display(Name = "Số Trực Phòng Ban")]
        public int SdtPhongBan { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}