namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsPictureSiteinformationCategoryGalleryPictureAttachmentNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PictureAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gallery_Id = c.Int(),
                        Picture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.Gallery_Id)
                .ForeignKey("dbo.Pictures", t => t.Picture_Id)
                .Index(t => t.Gallery_Id)
                .Index(t => t.Picture_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PictureAttachments", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.PictureAttachments", "Gallery_Id", "dbo.Galleries");
            DropForeignKey("dbo.Galleries", "Category_Id", "dbo.Categories");
            DropIndex("dbo.PictureAttachments", new[] { "Picture_Id" });
            DropIndex("dbo.PictureAttachments", new[] { "Gallery_Id" });
            DropIndex("dbo.Galleries", new[] { "Category_Id" });
            DropTable("dbo.PictureAttachments");
            DropTable("dbo.Pictures");
            DropTable("dbo.Galleries");
            DropTable("dbo.Categories");
        }
    }
}
