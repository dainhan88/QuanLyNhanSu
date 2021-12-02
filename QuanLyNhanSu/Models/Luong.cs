using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class Luong
    {
       [Key]
     
        public int ID { get; set; }
        [Display(Name = "Tháng")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Thang { get; set; }
        [Display(Name = "Nhân Viên")]
        public String IDNhanVien { get; set; }
        [Display(Name = "Lương Ngày")]
        public float LuongNgay { get; set; }
        [Display(Name = "Số ngày đi làm")]
        public float NgayCong { get; set; }
        public virtual NhanVien NhanViens { get; set; }

    }
}