namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "Status", c => c.String());
            AlterColumn("dbo.Dictionaries", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dictionaries", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Bills", "Status", c => c.String(nullable: false));
        }
    }
}
