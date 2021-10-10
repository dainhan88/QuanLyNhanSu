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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}