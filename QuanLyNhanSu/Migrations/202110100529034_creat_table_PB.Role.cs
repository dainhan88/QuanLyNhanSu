namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creat_table_PBRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhongBans",
                c => new
                    {
                        MaPhongBan = c.String(nullable: false, maxLength: 128),
                        TenPhongBan = c.String(),
                        DiaChiPhongBan = c.String(),
                        SdtPhongBan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhongBan);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
            DropTable("dbo.PhongBans");
        }
    }
}
