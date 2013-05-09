namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PARCELS",
                c => new
                    {
                        STRAP = c.String(nullable: false, maxLength: 128),
                        SITUS = c.String(),
                        ZIP_CODE = c.String(),
                        MAILING_ADDRESS = c.String(),
                        PROPERTY_USE = c.String(),
                        SUBDIVISION = c.String(),
                        LAND_AREA = c.Int(nullable: false),
                        INCORPORATION = c.String(),
                        SEC_TWP_RGE = c.String(),
                        CENSUS = c.String(),
                        WATERFRONT = c.String(),
                        ASSESSMENT_DESCRIPTION = c.String(),
                    })
                .PrimaryKey(t => t.STRAP);
            
            CreateTable(
                "dbo.OWNERS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        STRAP = c.String(maxLength: 128),
                        LN_NUM = c.Int(nullable: false),
                        NAME = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PARCELS", t => t.STRAP)
                .Index(t => t.STRAP);
            
            CreateTable(
                "dbo.CHARACTERISTICS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        STRAP = c.String(maxLength: 128),
                        CAT_CD = c.String(),
                        TP = c.String(),
                        CAT = c.String(),
                        DSCR = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PARCELS", t => t.STRAP)
                .Index(t => t.STRAP);
            
            CreateTable(
                "dbo.BUILDINGS",
                c => new
                    {
                        STRAP = c.String(nullable: false, maxLength: 128),
                        NUM = c.Int(nullable: false),
                        SITUS = c.String(),
                        TYPE = c.String(),
                        STYLE = c.String(),
                        BEDS = c.Int(nullable: false),
                        BATHS = c.Int(nullable: false),
                        HALF_BATHS = c.Int(nullable: false),
                        ROOMS = c.Int(nullable: false),
                        LIVING_UNITS = c.Int(nullable: false),
                        YEAR_BUILT = c.Int(),
                        GROSS_AREA = c.Int(),
                        LIVING_AREA = c.Int(),
                    })
                .PrimaryKey(t => new { t.STRAP, t.NUM })
                .ForeignKey("dbo.PARCELS", t => t.STRAP, cascadeDelete: true)
                .Index(t => t.STRAP);
            
            CreateTable(
                "dbo.STRUCTURAL_ELEMENTS",
                c => new
                    {
                        STRAP = c.String(nullable: false, maxLength: 128),
                        BUILDING_NUM = c.Int(nullable: false),
                        LN_NUM = c.Int(nullable: false),
                        CATEGORY = c.String(nullable: false, maxLength: 128),
                        DSCR = c.String(),
                        VALUE = c.String(),
                    })
                .PrimaryKey(t => new { t.STRAP, t.BUILDING_NUM, t.LN_NUM, t.CATEGORY })
                .ForeignKey("dbo.BUILDINGS", t => new { t.STRAP, t.BUILDING_NUM }, cascadeDelete: true)
                .Index(t => new { t.STRAP, t.BUILDING_NUM });
            
            CreateTable(
                "dbo.SUB_AREAS",
                c => new
                    {
                        STRAP = c.String(nullable: false, maxLength: 128),
                        BUILDING_NUM = c.Int(nullable: false),
                        LN_NUM = c.Int(nullable: false),
                        CD = c.String(nullable: false, maxLength: 128),
                        DSCR = c.String(),
                        GROSS_AREA = c.Int(nullable: false),
                        VALUE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.STRAP, t.BUILDING_NUM, t.LN_NUM, t.CD })
                .ForeignKey("dbo.BUILDINGS", t => new { t.STRAP, t.BUILDING_NUM }, cascadeDelete: true)
                .Index(t => new { t.STRAP, t.BUILDING_NUM });
            
            CreateTable(
                "dbo.TRANSFERS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        STRAP = c.String(maxLength: 128),
                        TRANS_DATE = c.DateTime(nullable: false),
                        AMOUNT = c.Int(nullable: false),
                        INSTRUMENT_NUM = c.String(),
                        TRANS_CODE = c.String(),
                        GRANTOR = c.String(),
                        INSTRUMENT_TYPE = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PARCELS", t => t.STRAP)
                .Index(t => t.STRAP);
            
            CreateTable(
                "dbo.EXEMPTIONS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        STRAP = c.String(maxLength: 128),
                        NUM = c.Int(nullable: false),
                        CD = c.String(),
                        GRANT_DATE = c.DateTime(nullable: false),
                        DSCR = c.String(),
                        VALUE = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PARCELS", t => t.STRAP)
                .Index(t => t.STRAP);
            
            CreateTable(
                "dbo.PARCEL_VALUES",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        STRAP = c.String(maxLength: 128),
                        YEAR = c.Int(nullable: false),
                        LAND = c.Int(nullable: false),
                        BUILDING = c.Int(nullable: false),
                        EXTRA_FEATURE = c.Int(nullable: false),
                        JUST = c.Int(nullable: false),
                        ASSESSED = c.Int(nullable: false),
                        EXEMPTIONS = c.Int(nullable: false),
                        TAXABLE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PARCELS", t => t.STRAP)
                .Index(t => t.STRAP);
            
            CreateTable(
                "dbo.AD_VALOREMS",
                c => new
                    {
                        AV_ID = c.Int(nullable: false, identity: true),
                        STRAP = c.String(maxLength: 128),
                        CODE = c.String(),
                        DSCR = c.String(),
                        MILL_RATE = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AV_ID)
                .ForeignKey("dbo.PARCELS", t => t.STRAP)
                .Index(t => t.STRAP);
            
            CreateTable(
                "dbo.NON_AD_VALOREMS",
                c => new
                    {
                        NAV_ID = c.Int(nullable: false, identity: true),
                        STRAP = c.String(maxLength: 128),
                        CODE = c.String(),
                        DSCR = c.String(),
                    })
                .PrimaryKey(t => t.NAV_ID)
                .ForeignKey("dbo.PARCELS", t => t.STRAP)
                .Index(t => t.STRAP);
            
            CreateTable(
                "dbo.EXTRA_FEATURES",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        STRAP = c.String(),
                        BUILDING_NUM = c.Int(nullable: false),
                        LN_NUM = c.Int(nullable: false),
                        DSCR = c.String(),
                        UNITS = c.Decimal(precision: 18, scale: 2),
                        UNIT_PRICE = c.Decimal(precision: 18, scale: 2),
                        YEAR_BUILT = c.Int(),
                        CD = c.String(),
                        UNIT_TYPE = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TANGIBLE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ACCOUNT_NUMBER = c.String(),
                        PROPERTY_ADDRESS = c.String(),
                        STRAP = c.String(),
                        OWNER_NAME = c.String(),
                        BUSINESS_TYPE = c.String(),
                        LOCAL_TAX_NO = c.String(),
                        MAILING_ADDRESS = c.String(),
                        LAST_RETURN_FILED = c.DateTime(nullable: false),
                        WAIVED_FLAG = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.NON_AD_VALOREMS", new[] { "STRAP" });
            DropIndex("dbo.AD_VALOREMS", new[] { "STRAP" });
            DropIndex("dbo.PARCEL_VALUES", new[] { "STRAP" });
            DropIndex("dbo.EXEMPTIONS", new[] { "STRAP" });
            DropIndex("dbo.TRANSFERS", new[] { "STRAP" });
            DropIndex("dbo.SUB_AREAS", new[] { "STRAP", "BUILDING_NUM" });
            DropIndex("dbo.STRUCTURAL_ELEMENTS", new[] { "STRAP", "BUILDING_NUM" });
            DropIndex("dbo.BUILDINGS", new[] { "STRAP" });
            DropIndex("dbo.CHARACTERISTICS", new[] { "STRAP" });
            DropIndex("dbo.OWNERS", new[] { "STRAP" });
            DropForeignKey("dbo.NON_AD_VALOREMS", "STRAP", "dbo.PARCELS");
            DropForeignKey("dbo.AD_VALOREMS", "STRAP", "dbo.PARCELS");
            DropForeignKey("dbo.PARCEL_VALUES", "STRAP", "dbo.PARCELS");
            DropForeignKey("dbo.EXEMPTIONS", "STRAP", "dbo.PARCELS");
            DropForeignKey("dbo.TRANSFERS", "STRAP", "dbo.PARCELS");
            DropForeignKey("dbo.SUB_AREAS", new[] { "STRAP", "BUILDING_NUM" }, "dbo.BUILDINGS");
            DropForeignKey("dbo.STRUCTURAL_ELEMENTS", new[] { "STRAP", "BUILDING_NUM" }, "dbo.BUILDINGS");
            DropForeignKey("dbo.BUILDINGS", "STRAP", "dbo.PARCELS");
            DropForeignKey("dbo.CHARACTERISTICS", "STRAP", "dbo.PARCELS");
            DropForeignKey("dbo.OWNERS", "STRAP", "dbo.PARCELS");
            DropTable("dbo.TANGIBLE");
            DropTable("dbo.EXTRA_FEATURES");
            DropTable("dbo.NON_AD_VALOREMS");
            DropTable("dbo.AD_VALOREMS");
            DropTable("dbo.PARCEL_VALUES");
            DropTable("dbo.EXEMPTIONS");
            DropTable("dbo.TRANSFERS");
            DropTable("dbo.SUB_AREAS");
            DropTable("dbo.STRUCTURAL_ELEMENTS");
            DropTable("dbo.BUILDINGS");
            DropTable("dbo.CHARACTERISTICS");
            DropTable("dbo.OWNERS");
            DropTable("dbo.PARCELS");
        }
    }
}
