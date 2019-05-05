namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clean : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactInfoes", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.ContactInfoes", new[] { "Picture_Id" });
            AddColumn("dbo.ContactInfoes", "Picture_Url", c => c.String());
            DropColumn("dbo.ContactInfoes", "Picture_Id");
            DropTable("dbo.Pictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageAddress = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContactInfoes", "Picture_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ContactInfoes", "Picture_Url");
            CreateIndex("dbo.ContactInfoes", "Picture_Id");
            AddForeignKey("dbo.ContactInfoes", "Picture_Id", "dbo.Pictures", "Id", cascadeDelete: true);
        }
    }
}
