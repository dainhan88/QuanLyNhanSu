using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class DangKyTuyenDung
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Họ và tên không được để trống !")]
        [Display(Name ="Họ và Tên")]
        public string Name { get; set; }



        [Display(Name ="Số Điện Thoại")]
        public int SDT { get; set; }


        [Display(Name = "Giới Tính")]
        public string GioiTinh { get; set; }


        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh Nhân Viên không được để trống !!!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Trình Độ Học Vấn")]
        public string TrinhDoHocVan { get; set; }


        
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }



        [Display(Name = "Gmail Cá Nhân")]
        public string Gmail { get; set; }



        [Display(Name = "Vị Trí Ứng Tuyển")]
        public string ViTriUngTuyen { get; set; }


        [Display(Name = "Kinh Nghiệm")]
        public string KinhNghiem { get; set; }
    }
}