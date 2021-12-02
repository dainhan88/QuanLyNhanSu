namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NVQL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "Note", c => c.String());
            DropColumn("dbo.NhanViens", "mnm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanViens", "mnm", c => c.String());
            DropColumn("dbo.NhanViens", "Note");
        }
    }
}
