namespace MUESystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dictionaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                        Reark = c.String(),
                        FirstCode = c.String(nullable: false),
                        SecondCode = c.String(),
                        ThirdCode = c.String(),
                        FourthCode = c.String(),
                        FifthCode = c.String(),
                        InfoValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dictionaries");
        }
    }
}
