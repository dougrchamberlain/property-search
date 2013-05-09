namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PARCELS", "MUNICIPALITY_CODE", c => c.String(maxLength: 5));
            AddColumn("dbo.PARCELS", "MUNICIPALITY_NAME", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PARCELS", "MUNICIPALITY_NAME");
            DropColumn("dbo.PARCELS", "MUNICIPALITY_CODE");
        }
    }
}
