namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "Picture_Id", c => c.Int());
            AddColumn("dbo.Pictures", "ImageAddress", c => c.String());
            CreateIndex("dbo.ContactInfoes", "Picture_Id");
            AddForeignKey("dbo.ContactInfoes", "Picture_Id", "dbo.Pictures", "Id");
            DropColumn("dbo.Pictures", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Image", c => c.Binary());
            DropForeignKey("dbo.ContactInfoes", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.ContactInfoes", new[] { "Picture_Id" });
            DropColumn("dbo.Pictures", "ImageAddress");
            DropColumn("dbo.ContactInfoes", "Picture_Id");
        }
    }
}
