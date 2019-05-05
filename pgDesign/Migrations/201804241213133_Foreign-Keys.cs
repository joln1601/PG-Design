namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactInfoes", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.ContactInfoes", new[] { "Picture_Id" });
            AlterColumn("dbo.ContactInfoes", "Picture_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactInfoes", "Picture_Id");
            AddForeignKey("dbo.ContactInfoes", "Picture_Id", "dbo.Pictures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactInfoes", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.ContactInfoes", new[] { "Picture_Id" });
            AlterColumn("dbo.ContactInfoes", "Picture_Id", c => c.Int());
            CreateIndex("dbo.ContactInfoes", "Picture_Id");
            AddForeignKey("dbo.ContactInfoes", "Picture_Id", "dbo.Pictures", "Id");
        }
    }
}
