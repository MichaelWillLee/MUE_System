namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "CreatPerson_ID", "dbo.Users");
            DropIndex("dbo.Bills", new[] { "CreatPerson_ID" });
            AlterColumn("dbo.Bills", "CreatPerson_ID", c => c.Int());
            CreateIndex("dbo.Bills", "CreatPerson_ID");
            AddForeignKey("dbo.Bills", "CreatPerson_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "CreatPerson_ID", "dbo.Users");
            DropIndex("dbo.Bills", new[] { "CreatPerson_ID" });
            AlterColumn("dbo.Bills", "CreatPerson_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bills", "CreatPerson_ID");
            AddForeignKey("dbo.Bills", "CreatPerson_ID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
