namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DKTD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangKyTuyenDungs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SDT = c.Int(nullable: false),
                        GioiTinh = c.String(),
                        TrinhDoHocVan = c.String(),
                        DiaChi = c.String(),
                        Gmail = c.String(),
                        ViTriUngTuyen = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DangKyTuyenDungs");
        }
    }
}
