namespace GibddService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsWaitForDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "IsWaitForDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "IsWaitForDelete");
        }
    }
}
