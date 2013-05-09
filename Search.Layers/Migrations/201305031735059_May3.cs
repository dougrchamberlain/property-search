namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class May3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PARCELS", "STATUS", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PARCELS", "STATUS", c => c.String(maxLength: 10));
        }
    }
}
