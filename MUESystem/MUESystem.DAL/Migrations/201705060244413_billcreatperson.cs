namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billcreatperson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "BillType_ID", "dbo.Dictionaries");
            DropForeignKey("dbo.Bills", "CreatPerson_ID", "dbo.Users");
            DropIndex("dbo.Bills", new[] { "BillType_ID" });
            DropIndex("dbo.Bills", new[] { "CreatPerson_ID" });
            AddColumn("dbo.Bills", "CreatPersonID", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "BillTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Bills", "CreatTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bills", "BillType_ID");
            DropColumn("dbo.Bills", "CreatPerson_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "CreatPerson_ID", c => c.Int());
            AddColumn("dbo.Bills", "BillType_ID", c => c.Int());
            AlterColumn("dbo.Bills", "CreatTime", c => c.String(nullable: false));
            DropColumn("dbo.Bills", "BillTypeID");
            DropColumn("dbo.Bills", "CreatPersonID");
            CreateIndex("dbo.Bills", "CreatPerson_ID");
            CreateIndex("dbo.Bills", "BillType_ID");
            AddForeignKey("dbo.Bills", "CreatPerson_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Bills", "BillType_ID", "dbo.Dictionaries", "ID");
        }
    }
}
