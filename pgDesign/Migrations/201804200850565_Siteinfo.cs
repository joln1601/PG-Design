namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Siteinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Siteinformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Siteinformations");
        }
    }
}
