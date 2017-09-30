namespace PAAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Application", "Applicant_Specialization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Application", "Applicant_Specialization", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
