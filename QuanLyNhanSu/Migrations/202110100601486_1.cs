namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhongBans", "TenPhongBan", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhongBans", "TenPhongBan", c => c.String());
        }
    }
}
