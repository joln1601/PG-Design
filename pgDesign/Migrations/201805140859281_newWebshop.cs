namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newWebshop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Webshops", "Id", "dbo.Pictures");
            DropIndex("dbo.Webshops", new[] { "Id" });
            DropPrimaryKey("dbo.Webshops");
            AddColumn("dbo.Webshops", "Picture_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Webshops", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Webshops", "Id");
            CreateIndex("dbo.Webshops", "Picture_Id");
            AddForeignKey("dbo.Webshops", "Picture_Id", "dbo.Pictures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Webshops", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.Webshops", new[] { "Picture_Id" });
            DropPrimaryKey("dbo.Webshops");
            AlterColumn("dbo.Webshops", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Webshops", "Picture_Id");
            AddPrimaryKey("dbo.Webshops", "Id");
            CreateIndex("dbo.Webshops", "Id");
            AddForeignKey("dbo.Webshops", "Id", "dbo.Pictures", "Id");
        }
    }
}
