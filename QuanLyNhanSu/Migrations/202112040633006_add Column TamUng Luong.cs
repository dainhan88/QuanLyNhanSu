namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnTamUngLuong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Luongs", "TamUng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Luongs", "TamUng");
        }
    }
}
