namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "RegistrationTime");
            DropColumn("dbo.Users", "LoginTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "LoginTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "RegistrationTime", c => c.DateTime(nullable: false));
        }
    }
}
