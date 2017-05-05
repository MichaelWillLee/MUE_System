namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "CreatPerson_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bills", "CreatPerson_ID");
            AddForeignKey("dbo.Bills", "CreatPerson_ID", "dbo.Users", "ID", cascadeDelete: true);
            DropColumn("dbo.Bills", "CreaterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "CreaterID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bills", "CreatPerson_ID", "dbo.Users");
            DropIndex("dbo.Bills", new[] { "CreatPerson_ID" });
            DropColumn("dbo.Bills", "CreatPerson_ID");
        }
    }
}
