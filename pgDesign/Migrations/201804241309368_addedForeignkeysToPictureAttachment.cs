namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignkeysToPictureAttachment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PictureAttachments", "Gallery_Id", "dbo.Galleries");
            DropForeignKey("dbo.PictureAttachments", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.PictureAttachments", new[] { "Gallery_Id" });
            DropIndex("dbo.PictureAttachments", new[] { "Picture_Id" });
            AlterColumn("dbo.PictureAttachments", "Gallery_id", c => c.Int(nullable: false));
            AlterColumn("dbo.PictureAttachments", "Picture_id", c => c.Int(nullable: false));
            CreateIndex("dbo.PictureAttachments", "Picture_id");
            CreateIndex("dbo.PictureAttachments", "Gallery_id");
            AddForeignKey("dbo.PictureAttachments", "Gallery_id", "dbo.Galleries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PictureAttachments", "Picture_id", "dbo.Pictures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PictureAttachments", "Picture_id", "dbo.Pictures");
            DropForeignKey("dbo.PictureAttachments", "Gallery_id", "dbo.Galleries");
            DropIndex("dbo.PictureAttachments", new[] { "Gallery_id" });
            DropIndex("dbo.PictureAttachments", new[] { "Picture_id" });
            AlterColumn("dbo.PictureAttachments", "Picture_id", c => c.Int());
            AlterColumn("dbo.PictureAttachments", "Gallery_id", c => c.Int());
            CreateIndex("dbo.PictureAttachments", "Picture_Id");
            CreateIndex("dbo.PictureAttachments", "Gallery_Id");
            AddForeignKey("dbo.PictureAttachments", "Picture_Id", "dbo.Pictures", "Id");
            AddForeignKey("dbo.PictureAttachments", "Gallery_Id", "dbo.Galleries", "Id");
        }
    }
}
