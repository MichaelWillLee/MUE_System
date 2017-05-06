namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebillcreatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "CreatTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "CreatTime", c => c.DateTime(nullable: false));
        }
    }
}
