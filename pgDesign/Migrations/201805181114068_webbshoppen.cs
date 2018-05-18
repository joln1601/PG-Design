namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webbshoppen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Webshops", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.Webshops", new[] { "Picture_Id" });
            AddColumn("dbo.Webshops", "Picture_Url", c => c.String());
            DropColumn("dbo.Webshops", "Picture_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Webshops", "Picture_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Webshops", "Picture_Url");
            CreateIndex("dbo.Webshops", "Picture_Id");
            AddForeignKey("dbo.Webshops", "Picture_Id", "dbo.Pictures", "Id", cascadeDelete: true);
        }
    }
}
