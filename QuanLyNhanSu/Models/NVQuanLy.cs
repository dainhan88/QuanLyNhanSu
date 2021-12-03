using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class NVQuanLy : NhanVien
    {
        public string Note { get; set; }
    }
}