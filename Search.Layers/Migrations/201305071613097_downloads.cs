namespace Search.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class downloads : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DOWNLOADS",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name1 = c.String(),
                        name_add2 = c.String(),
                        name_add3 = c.String(),
                        name_add4 = c.String(),
                        name_add5 = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zip = c.String(),
                        country = c.String(),
                        locn = c.String(),
                        locs = c.String(),
                        locd = c.String(),
                        unit = c.String(),
                        loccity = c.String(),
                        locstate = c.String(),
                        loczip = c.String(),
                        stcd = c.String(),
                        nghb = c.String(),
                        subd = c.String(),
                        txcd = c.String(),
                        del_area = c.String(),
                        sect = c.String(),
                        twsp = c.String(),
                        rang = c.String(),
                        BLOCK = c.String(),
                        lot = c.String(),
                        gulfbay = c.String(),
                        census = c.String(),
                        just = c.Decimal(precision: 18, scale: 2),
                        assd = c.Decimal(precision: 18, scale: 2),
                        txbl = c.Decimal(precision: 18, scale: 2),
                        exemptions = c.Decimal(precision: 18, scale: 2),
                        homestead = c.String(),
                        improvemt = c.Decimal(precision: 18, scale: 2),
                        exempt1 = c.Short(),
                        exempt2 = c.Short(),
                        exempt3 = c.Short(),
                        exempt4 = c.Short(),
                        exempt5 = c.Short(),
                        lnvs_n = c.Decimal(precision: 18, scale: 2),
                        zoning_1 = c.String(),
                        zoning_2 = c.String(),
                        sale_amt = c.Decimal(precision: 18, scale: 2),
                        sale_date = c.String(),
                        qual_code = c.String(),
                        or_book = c.String(),
                        or_page = c.String(),
                        legalrefer = c.String(),
                        POOL = c.String(),
                        pool_built = c.Int(),
                        build_clas = c.String(),
                        grnd_area = c.Int(),
                        living = c.Int(),
                        bedr = c.Int(),
                        bath = c.Int(),
                        halfbath = c.Int(),
                        livunits = c.Int(),
                        yrbl = c.Int(),
                        legal1 = c.String(),
                        legal2 = c.String(),
                        legal3 = c.String(),
                        legal4 = c.String(),
                        lsqft = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DOWNLOADS");
        }
    }
}
