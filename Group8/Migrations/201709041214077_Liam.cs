namespace Group8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Liam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        Document_ID = c.Int(nullable: false, identity: true),
                        Application_ID = c.Int(nullable: false),
                        Student_No = c.Int(nullable: false),
                        Document_Name = c.String(),
                        Document_Status = c.String(),
                    })
                .PrimaryKey(t => t.Document_ID)
                .ForeignKey("dbo.Application", t => t.Application_ID, cascadeDelete: true)
                .Index(t => t.Application_ID);
            
            CreateTable(
                "dbo.Evaluator",
                c => new
                    {
                        Evaluator_ID = c.Int(nullable: false, identity: true),
                        Evaluator_First_Name = c.String(),
                        Evaluator_Last_Name = c.String(),
                        Evaluator_ID_Number = c.String(),
                        Evaluator_Email = c.String(),
                        Evaluator_Contact_No = c.String(),
                        Evaluator_Type = c.String(),
                        Evaluator_Status = c.String(),
                    })
                .PrimaryKey(t => t.Evaluator_ID);
            
            CreateTable(
                "dbo.Interview",
                c => new
                    {
                        Interview_ID = c.Int(nullable: false, identity: true),
                        Evaluator_ID = c.Int(nullable: false),
                        PGC_ID = c.Int(nullable: false),
                        Interview_Date = c.DateTime(nullable: false),
                        Interview_Time = c.DateTime(nullable: false),
                        Interview_Venue = c.String(),
                        Interview_Status = c.Int(nullable: false),
                        Application_Application_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Interview_ID)
                .ForeignKey("dbo.Application", t => t.Application_Application_ID)
                .ForeignKey("dbo.Evaluator", t => t.Evaluator_ID, cascadeDelete: true)
                .ForeignKey("dbo.PGC", t => t.PGC_ID, cascadeDelete: true)
                .Index(t => t.Evaluator_ID)
                .Index(t => t.PGC_ID)
                .Index(t => t.Application_Application_ID);
            
            CreateTable(
                "dbo.PGC",
                c => new
                    {
                        PGC_ID = c.Int(nullable: false, identity: true),
                        PGC_First_Name = c.String(),
                        PGC_Last_Name = c.String(),
                        PGC_ID_Number = c.String(),
                        PGC_Email = c.String(),
                        PGC_Contact_No = c.String(),
                        PGC_Status = c.String(),
                    })
                .PrimaryKey(t => t.PGC_ID);
            
            CreateTable(
                "dbo.PGFO",
                c => new
                    {
                        PGFO_ID = c.Int(nullable: false, identity: true),
                        PGFO_First_Name = c.String(),
                        PGFO_Last_Name = c.String(),
                        PGFO_ID_Number = c.String(),
                        PGFO_Email = c.String(),
                        PGFO_Contact_No = c.String(),
                        PGFO_Status = c.String(),
                    })
                .PrimaryKey(t => t.PGFO_ID);
            
            CreateTable(
                "dbo.PGO",
                c => new
                    {
                        PGO_ID = c.Int(nullable: false, identity: true),
                        PGO_First_Name = c.String(),
                        PGO_Last_Name = c.String(),
                        PGO_ID_Number = c.String(),
                        PGO_Email = c.String(),
                        PGO_Contact_No = c.String(),
                        PGO_Status = c.String(),
                    })
                .PrimaryKey(t => t.PGO_ID);
            
            AddColumn("dbo.Application", "PGO_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Application", "PGFO_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Application", "PGC_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Application", "Evaluator_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Application", "Applicant_ID_Number", c => c.String());
            AlterColumn("dbo.Application", "Applicant_Street_No", c => c.Int(nullable: false));
            CreateIndex("dbo.Application", "PGO_ID");
            CreateIndex("dbo.Application", "PGFO_ID");
            CreateIndex("dbo.Application", "PGC_ID");
            CreateIndex("dbo.Application", "Evaluator_ID");
            AddForeignKey("dbo.Application", "Evaluator_ID", "dbo.Evaluator", "Evaluator_ID", cascadeDelete: true);
            AddForeignKey("dbo.Application", "PGC_ID", "dbo.PGC", "PGC_ID", cascadeDelete: true);
            AddForeignKey("dbo.Application", "PGFO_ID", "dbo.PGFO", "PGFO_ID", cascadeDelete: true);
            AddForeignKey("dbo.Application", "PGO_ID", "dbo.PGO", "PGO_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Application", "PGO_ID", "dbo.PGO");
            DropForeignKey("dbo.Application", "PGFO_ID", "dbo.PGFO");
            DropForeignKey("dbo.Interview", "PGC_ID", "dbo.PGC");
            DropForeignKey("dbo.Application", "PGC_ID", "dbo.PGC");
            DropForeignKey("dbo.Interview", "Evaluator_ID", "dbo.Evaluator");
            DropForeignKey("dbo.Interview", "Application_Application_ID", "dbo.Application");
            DropForeignKey("dbo.Application", "Evaluator_ID", "dbo.Evaluator");
            DropForeignKey("dbo.Document", "Application_ID", "dbo.Application");
            DropIndex("dbo.Interview", new[] { "Application_Application_ID" });
            DropIndex("dbo.Interview", new[] { "PGC_ID" });
            DropIndex("dbo.Interview", new[] { "Evaluator_ID" });
            DropIndex("dbo.Document", new[] { "Application_ID" });
            DropIndex("dbo.Application", new[] { "Evaluator_ID" });
            DropIndex("dbo.Application", new[] { "PGC_ID" });
            DropIndex("dbo.Application", new[] { "PGFO_ID" });
            DropIndex("dbo.Application", new[] { "PGO_ID" });
            AlterColumn("dbo.Application", "Applicant_Street_No", c => c.String());
            DropColumn("dbo.Application", "Applicant_ID_Number");
            DropColumn("dbo.Application", "Evaluator_ID");
            DropColumn("dbo.Application", "PGC_ID");
            DropColumn("dbo.Application", "PGFO_ID");
            DropColumn("dbo.Application", "PGO_ID");
            DropTable("dbo.PGO");
            DropTable("dbo.PGFO");
            DropTable("dbo.PGC");
            DropTable("dbo.Interview");
            DropTable("dbo.Evaluator");
            DropTable("dbo.Document");
        }
    }
}
