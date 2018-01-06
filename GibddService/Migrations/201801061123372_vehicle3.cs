namespace GibddService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicle3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "MarkId", "dbo.Marks");
            DropForeignKey("dbo.Vehicles", "Model_Id", "dbo.Models");
            DropIndex("dbo.Vehicles", new[] { "Model_Id" });
            DropIndex("dbo.Models", new[] { "MarkId" });
            DropColumn("dbo.Vehicles", "ModelId");
            DropColumn("dbo.Vehicles", "Model_Id");
        }
        
        public override void Down()
        {         
            AddColumn("dbo.Vehicles", "Model_Id", c => c.Int());
            AddColumn("dbo.Vehicles", "ModelId", c => c.String());
            CreateIndex("dbo.Models", "MarkId");
            CreateIndex("dbo.Vehicles", "Model_Id");
            AddForeignKey("dbo.Vehicles", "Model_Id", "dbo.Models", "Id");
            AddForeignKey("dbo.Models", "MarkId", "dbo.Marks", "Id", cascadeDelete: true);
        }
    }
}
