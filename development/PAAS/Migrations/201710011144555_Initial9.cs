namespace PAAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "Document_File", c => c.Binary(nullable: false));
            AlterColumn("dbo.Application", "Applicant_Contact_No", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Application", "Applicant_Contact_No", c => c.String());
            DropColumn("dbo.Document", "Document_File");
        }
    }
}
