namespace pgDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "Biography", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfoes", "Biography");
        }
    }
}
