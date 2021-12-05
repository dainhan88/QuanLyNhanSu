namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableNVTT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "ThoiGianThucTap", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanViens", "ThoiGianThucTap");
        }
    }
}
