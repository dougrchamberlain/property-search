namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdatedatefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PARCELS", "LAST_UPDATED", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PARCELS", "LAST_UPDATED");
        }
    }
}
