namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qlimga2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NhanViens", "QLImgName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanViens", "QLImgName", c => c.String());
        }
    }
}
