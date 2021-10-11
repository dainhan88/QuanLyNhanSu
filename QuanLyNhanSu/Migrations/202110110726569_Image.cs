namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "NhanVienImgName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanViens", "NhanVienImgName");
        }
    }
}
