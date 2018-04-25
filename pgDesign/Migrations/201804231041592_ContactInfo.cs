namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Phone = c.String(),
                        Fname = c.String(),
                        LName = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactInfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ContactInfoes", new[] { "UserId" });
            DropTable("dbo.ContactInfoes");
        }
    }
}
