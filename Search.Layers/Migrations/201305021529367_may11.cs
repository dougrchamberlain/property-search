namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class may11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BUILDINGS", "STORY_NUM", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BUILDINGS", "STORY_NUM");
        }
    }
}
