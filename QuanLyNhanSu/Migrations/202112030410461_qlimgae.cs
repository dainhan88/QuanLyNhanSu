namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qlimgae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "QLImgName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanViens", "QLImgName");
        }
    }
}
