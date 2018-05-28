namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editwebbshop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Galleries", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.PictureAttachments", "Gallery_id", "dbo.Galleries");
            DropForeignKey("dbo.PictureAttachments", "Picture_id", "dbo.Pictures");
            DropIndex("dbo.Galleries", new[] { "Category_Id" });
            DropIndex("dbo.PictureAttachments", new[] { "Picture_id" });
            DropIndex("dbo.PictureAttachments", new[] { "Gallery_id" });
            CreateTable(
                "dbo.Webshops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Picture_Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Categories");
            DropTable("dbo.Galleries");
            DropTable("dbo.PictureAttachments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PictureAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Picture_id = c.Int(nullable: false),
                        Gallery_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Webshops");
            CreateIndex("dbo.PictureAttachments", "Gallery_id");
            CreateIndex("dbo.PictureAttachments", "Picture_id");
            CreateIndex("dbo.Galleries", "Category_Id");
            AddForeignKey("dbo.PictureAttachments", "Picture_id", "dbo.Pictures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PictureAttachments", "Gallery_id", "dbo.Galleries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Galleries", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
