namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateAddExtraFeatures : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EXTRA_FEATURES", "STRAP", c => c.String(maxLength: 128));
            AddForeignKey("dbo.EXTRA_FEATURES", "STRAP", "dbo.PARCELS", "STRAP");
            CreateIndex("dbo.EXTRA_FEATURES", "STRAP");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EXTRA_FEATURES", new[] { "STRAP" });
            DropForeignKey("dbo.EXTRA_FEATURES", "STRAP", "dbo.PARCELS");
            AlterColumn("dbo.EXTRA_FEATURES", "STRAP", c => c.String());
        }
    }
}
