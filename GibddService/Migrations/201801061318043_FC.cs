namespace GibddService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FC : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "Model_Id", "dbo.Models");
            DropIndex("dbo.Vehicles", new[] { "Model_Id" });
            DropColumn("dbo.Vehicles", "ModelId");
            RenameColumn(table: "dbo.Vehicles", name: "Model_Id", newName: "ModelId");
            AlterColumn("dbo.Vehicles", "StateNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "SerialNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "ModelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "ModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "ModelId");
            AddForeignKey("dbo.Vehicles", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            AlterColumn("dbo.Vehicles", "ModelId", c => c.Int());
            AlterColumn("dbo.Vehicles", "ModelId", c => c.String());
            AlterColumn("dbo.Vehicles", "SerialNumber", c => c.String());
            AlterColumn("dbo.Vehicles", "StateNumber", c => c.String());
            RenameColumn(table: "dbo.Vehicles", name: "ModelId", newName: "Model_Id");
            AddColumn("dbo.Vehicles", "ModelId", c => c.String());
            CreateIndex("dbo.Vehicles", "Model_Id");
            AddForeignKey("dbo.Vehicles", "Model_Id", "dbo.Models", "Id");
        }
    }
}
