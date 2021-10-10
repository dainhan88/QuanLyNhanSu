namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_NV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChucVus",
                c => new
                    {
                        MaChucVu = c.String(nullable: false, maxLength: 128),
                        TenChucVu = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaChucVu);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        IDNhanVien = c.String(nullable: false, maxLength: 128),
                        NameNhanVien = c.String(nullable: false),
                        NgaySinhNV = c.DateTime(nullable: false),
                        SDTNhanVienName = c.String(),
                        GioiTinhNhanVien = c.String(),
                        DiaChiNhanVien = c.String(),
                        CCCDNhanVien = c.String(),
                        MaChucVu = c.String(maxLength: 128),
                        MaPhongBan = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDNhanVien)
                .ForeignKey("dbo.ChucVus", t => t.MaChucVu)
                .ForeignKey("dbo.PhongBans", t => t.MaPhongBan)
                .Index(t => t.MaChucVu)
                .Index(t => t.MaPhongBan);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanViens", "MaPhongBan", "dbo.PhongBans");
            DropForeignKey("dbo.NhanViens", "MaChucVu", "dbo.ChucVus");
            DropIndex("dbo.NhanViens", new[] { "MaPhongBan" });
            DropIndex("dbo.NhanViens", new[] { "MaChucVu" });
            DropTable("dbo.NhanViens");
            DropTable("dbo.ChucVus");
        }
    }
}
