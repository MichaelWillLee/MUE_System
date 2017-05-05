namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billbilltype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "BillType_ID", c => c.Int());
            CreateIndex("dbo.Bills", "BillType_ID");
            AddForeignKey("dbo.Bills", "BillType_ID", "dbo.Dictionaries", "ID");
            DropColumn("dbo.Bills", "BillTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "BillTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bills", "BillType_ID", "dbo.Dictionaries");
            DropIndex("dbo.Bills", new[] { "BillType_ID" });
            DropColumn("dbo.Bills", "BillType_ID");
        }
    }
}
