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
        public string MaPhongBan { get; set; }


        [Display(Name = "Tên Phòng Ban")]
        public string TenPhongBan { get; set; }


        [Display(Name = "Địa chỉ Phòng Ban")]
        public string DiaChiPhongBan { get; set; }


        [Display(Name = "Số điện thoại Phòng Ban")]
        public int SdtPhongBan { get; set; }
        //public ICollection<NhanVien> NhanViens { get; set; }
    }
}