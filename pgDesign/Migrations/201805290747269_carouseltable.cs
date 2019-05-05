namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carouseltable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carousels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uri = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carousels");
        }
    }
}
