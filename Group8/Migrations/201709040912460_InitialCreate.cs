namespace Group8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Application_ID = c.Int(nullable: false, identity: true),
                        Student_No = c.Int(nullable: false),
                        Application_Status = c.String(),
                        Applicant_First_Name = c.String(),
                        Applicant_Last_Name = c.String(),
                        Applicant_Email = c.String(),
                        Applicant_Contact_No = c.String(),
                        Applicant_School = c.String(),
                        Applicant_Faculty = c.String(),
                        Applicant_Street_No = c.String(),
                        Applicant_Street_Name = c.String(),
                        Applicant_Suburb = c.String(),
                        Applicant_City = c.String(),
                        Applicant_Province = c.String(),
                    })
                .PrimaryKey(t => t.Application_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Application");
        }
    }
}
