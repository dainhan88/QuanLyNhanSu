using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class Role
    {
        [Key]
        [StringLength(10)]
        [Display(Name ="ID")]
        public string RoleID { get; set; }
        [Display(Name ="Đối Tượng")]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}