namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class may2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PARCELS", "POOL_FLAG", c => c.Boolean(nullable: false));
            AddColumn("dbo.PARCELS", "DOCK_FLAG", c => c.Boolean(nullable: false));
            AddColumn("dbo.PARCELS", "SEAWALL_FLAG", c => c.Boolean(nullable: false));
            AddColumn("dbo.PARCELS", "TENNIS_FLAG", c => c.Boolean(nullable: false));
            AddColumn("dbo.PARCELS", "VACANT_FLAG", c => c.Boolean(nullable: false));
            AddColumn("dbo.PARCELS", "STATUS", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PARCELS", "STATUS");
            DropColumn("dbo.PARCELS", "VACANT_FLAG");
            DropColumn("dbo.PARCELS", "TENNIS_FLAG");
            DropColumn("dbo.PARCELS", "SEAWALL_FLAG");
            DropColumn("dbo.PARCELS", "DOCK_FLAG");
            DropColumn("dbo.PARCELS", "POOL_FLAG");
        }
    }
}
