namespace PAAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Application_ID = c.Int(nullable: false, identity: true),
                        PGO_ID = c.Int(nullable: false),
                        PGFO_ID = c.Int(nullable: false),
                        PGC_ID = c.Int(nullable: false),
                        Evaluator_ID = c.Int(nullable: false),
                        Student_No = c.String(nullable: false, maxLength: 50),
                        Application_Status = c.String(),
                        Application_Recommend_Desc = c.String(),
                        Application_Decision_Desc = c.String(),
                        Applicant_First_Name = c.String(nullable: false, maxLength: 50),
                        Applicant_Last_Name = c.String(nullable: false, maxLength: 50),
                        Applicant_ID_Number = c.String(nullable: false, maxLength: 13),
                        Applicant_Email = c.String(nullable: false),
                        Applicant_Contact_No = c.String(),
                        Applicant_Specialization = c.String(nullable: false, maxLength: 50),
                        Applicant_School = c.String(nullable: false, maxLength: 50),
                        Applicant_Faculty = c.String(nullable: false, maxLength: 50),
                        Applicant_Street_No = c.String(nullable: false, maxLength: 50),
                        Applicant_Street_Name = c.String(nullable: false, maxLength: 50),
                        Applicant_Suburb = c.String(nullable: false, maxLength: 50),
                        Applicant_City = c.String(nullable: false, maxLength: 50),
                        Applicant_Province = c.String(),
                    })
                .PrimaryKey(t => t.Application_ID)
                .ForeignKey("dbo.Evaluator", t => t.Evaluator_ID)
                .ForeignKey("dbo.PGC", t => t.PGC_ID)
                .ForeignKey("dbo.PGFO", t => t.PGFO_ID)
                .ForeignKey("dbo.PGO", t => t.PGO_ID)
                .Index(t => t.PGO_ID)
                .Index(t => t.PGFO_ID)
                .Index(t => t.PGC_ID)
                .Index(t => t.Evaluator_ID);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        Document_ID = c.Int(nullable: false, identity: true),
                        Application_ID = c.Int(nullable: false),
                        Document_Name = c.String(nullable: false, maxLength: 50),
                        Document_Type = c.String(),
                    })
                .PrimaryKey(t => t.Document_ID)
                .ForeignKey("dbo.Application", t => t.Application_ID)
                .Index(t => t.Application_ID);
            
            CreateTable(
                "dbo.Evaluator",
                c => new
                    {
                        Evaluator_ID = c.Int(nullable: false, identity: true),
                        Evaluator_First_Name = c.String(nullable: false, maxLength: 50),
                        Evaluator_Last_Name = c.String(nullable: false, maxLength: 50),
                        Evaluator_ID_Number = c.String(nullable: false, maxLength: 13),
                        Evaluator_Email = c.String(nullable: false),
                        Evaluator_Contact_No = c.String(),
                        Evaluator_Type = c.String(),
                        Evaluator_Password = c.String(nullable: false, maxLength: 20),
                        Evaluator_Status = c.String(),
                    })
                .PrimaryKey(t => t.Evaluator_ID);
            
            CreateTable(
                "dbo.Interview",
                c => new
                    {
                        Interview_ID = c.Int(nullable: false, identity: true),
                        Evaluator_ID = c.Int(nullable: false),
                        Application_ID = c.Int(nullable: false),
                        Interview_Date = c.DateTime(nullable: false),
                        Interview_Time = c.DateTime(nullable: false),
                        Interview_Venue = c.String(nullable: false, maxLength: 50),
                        Interview_Status = c.Int(nullable: false),
                        PGC_PGC_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Interview_ID)
                .ForeignKey("dbo.Application", t => t.Application_ID)
                .ForeignKey("dbo.Evaluator", t => t.Evaluator_ID)
                .ForeignKey("dbo.PGC", t => t.PGC_PGC_ID)
                .Index(t => t.Evaluator_ID)
                .Index(t => t.Application_ID)
                .Index(t => t.PGC_PGC_ID);
            
            CreateTable(
                "dbo.PGC",
                c => new
                    {
                        PGC_ID = c.Int(nullable: false, identity: true),
                        PGC_First_Name = c.String(nullable: false, maxLength: 50),
                        PGC_Last_Name = c.String(nullable: false, maxLength: 50),
                        PGC_ID_Number = c.String(nullable: false, maxLength: 13),
                        PGC_Email = c.String(nullable: false),
                        PGC_Contact_No = c.String(),
                        PGC_Password = c.String(nullable: false, maxLength: 20),
                        PGC_Status = c.String(),
                    })
                .PrimaryKey(t => t.PGC_ID);
            
            CreateTable(
                "dbo.PGFO",
                c => new
                    {
                        PGFO_ID = c.Int(nullable: false, identity: true),
                        PGFO_First_Name = c.String(nullable: false, maxLength: 50),
                        PGFO_Last_Name = c.String(nullable: false, maxLength: 50),
                        PGFO_ID_Number = c.String(nullable: false, maxLength: 13),
                        PGFO_Email = c.String(nullable: false),
                        PGFO_Contact_No = c.String(),
                        PGFO_Password = c.String(nullable: false, maxLength: 20),
                        PGFO_Status = c.String(),
                    })
                .PrimaryKey(t => t.PGFO_ID);
            
            CreateTable(
                "dbo.PGO",
                c => new
                    {
                        PGO_ID = c.Int(nullable: false, identity: true),
                        PGO_First_Name = c.String(nullable: false, maxLength: 50),
                        PGO_Last_Name = c.String(nullable: false, maxLength: 50),
                        PGO_ID_Number = c.String(nullable: false, maxLength: 13),
                        PGO_Email = c.String(nullable: false),
                        PGO_Contact_No = c.String(),
                        PGO_Password = c.String(nullable: false, maxLength: 20),
                        PGO_Status = c.String(),
                    })
                .PrimaryKey(t => t.PGO_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Application", "PGO_ID", "dbo.PGO");
            DropForeignKey("dbo.Application", "PGFO_ID", "dbo.PGFO");
            DropForeignKey("dbo.Application", "PGC_ID", "dbo.PGC");
            DropForeignKey("dbo.Interview", "PGC_PGC_ID", "dbo.PGC");
            DropForeignKey("dbo.Interview", "Evaluator_ID", "dbo.Evaluator");
            DropForeignKey("dbo.Interview", "Application_ID", "dbo.Application");
            DropForeignKey("dbo.Application", "Evaluator_ID", "dbo.Evaluator");
            DropForeignKey("dbo.Document", "Application_ID", "dbo.Application");
            DropIndex("dbo.Interview", new[] { "PGC_PGC_ID" });
            DropIndex("dbo.Interview", new[] { "Application_ID" });
            DropIndex("dbo.Interview", new[] { "Evaluator_ID" });
            DropIndex("dbo.Document", new[] { "Application_ID" });
            DropIndex("dbo.Application", new[] { "Evaluator_ID" });
            DropIndex("dbo.Application", new[] { "PGC_ID" });
            DropIndex("dbo.Application", new[] { "PGFO_ID" });
            DropIndex("dbo.Application", new[] { "PGO_ID" });
            DropTable("dbo.PGO");
            DropTable("dbo.PGFO");
            DropTable("dbo.PGC");
            DropTable("dbo.Interview");
            DropTable("dbo.Evaluator");
            DropTable("dbo.Document");
            DropTable("dbo.Application");
        }
    }
}
