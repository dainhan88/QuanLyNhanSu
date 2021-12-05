namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnKinhNghiem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DangKyTuyenDungs", "KinhNghiem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DangKyTuyenDungs", "KinhNghiem");
        }
    }
}
