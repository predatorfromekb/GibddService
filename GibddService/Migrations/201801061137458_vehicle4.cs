namespace GibddService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicle4 : DbMigration
    {
        public override void Up()
        {     
            AddColumn("dbo.Vehicles", "ModelId", c => c.String());
            AddColumn("dbo.Vehicles", "Model_Id", c => c.Int());
            CreateIndex("dbo.Vehicles", "Model_Id");
            AddForeignKey("dbo.Vehicles", "Model_Id", "dbo.Models", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.Models", "MarkId", "dbo.Marks");
            DropIndex("dbo.Models", new[] { "MarkId" });
            DropIndex("dbo.Vehicles", new[] { "Model_Id" });
            DropColumn("dbo.Vehicles", "Model_Id");
            DropColumn("dbo.Vehicles", "ModelId");
        }
    }
}
