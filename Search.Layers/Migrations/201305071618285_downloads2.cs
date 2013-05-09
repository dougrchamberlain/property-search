namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class downloads2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DOWNLOADS", "DOWNLOAD_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DOWNLOADS", "DOWNLOAD_ID", c => c.Int(nullable: false));
        }
    }
}
