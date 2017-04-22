namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Status");
            AddColumn("dbo.Users", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
        }
    }
}
