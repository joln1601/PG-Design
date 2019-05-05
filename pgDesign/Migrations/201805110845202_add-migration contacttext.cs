namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationcontacttext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "ContactUs", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfoes", "ContactUs");
        }
    }
}
