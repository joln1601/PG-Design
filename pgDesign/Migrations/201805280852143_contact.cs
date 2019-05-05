namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactInfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ContactInfoes", new[] { "UserId" });
            DropColumn("dbo.ContactInfoes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactInfoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ContactInfoes", "UserId");
            AddForeignKey("dbo.ContactInfoes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
