namespace PAAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Application", "Applicant_Province", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Interview", "Interview_Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Interview", "Interview_Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Application", "Applicant_Province", c => c.String());
        }
    }
}
