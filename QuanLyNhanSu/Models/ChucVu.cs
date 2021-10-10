using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class ChucVu
    {
        [Key]
        [Display(Name = "Mã Chức Vụ")]
        [Required(ErrorMessage = "Mã Chức Vụ không được để trống !!!!")]
        public string MaChucVu { get; set; }


        [Display(Name = "Tên Chức Vụ")]
        [Required(ErrorMessage = "Tên Chức Vụ không được để trống !!!!")]
        public string TenChucVu { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}