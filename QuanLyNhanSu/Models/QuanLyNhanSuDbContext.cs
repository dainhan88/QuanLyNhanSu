using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyNhanSu.Models
{
    public partial class QuanLyNhanSuDbContext : DbContext
    {
        public QuanLyNhanSuDbContext()
            : base("name=QuanLyNhanSuDbContext")
        {
        }
        public virtual DbSet<Role> Roles { get; set; }
     
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Luong> luongs { get; set; }
        public virtual DbSet<NVQuanLy> NVQuanLys { get; set; }
        public virtual DbSet<DangKyTuyenDung> DangKyTuyenDungs { get; set; }
        public virtual DbSet<NhanVienThucTap> NhanVienThucTaps { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
