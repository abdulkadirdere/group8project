namespace PAAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Application", "Evaluator_ID", "dbo.Evaluator");
            DropForeignKey("dbo.Application", "PGC_ID", "dbo.PGC");
            DropForeignKey("dbo.Application", "PGFO_ID", "dbo.PGFO");
            DropForeignKey("dbo.Application", "PGO_ID", "dbo.PGO");
            DropIndex("dbo.Application", new[] { "PGO_ID" });
            DropIndex("dbo.Application", new[] { "PGFO_ID" });
            DropIndex("dbo.Application", new[] { "PGC_ID" });
            DropIndex("dbo.Application", new[] { "Evaluator_ID" });
            DropColumn("dbo.Application", "PGO_ID");
            DropColumn("dbo.Application", "PGFO_ID");
            DropColumn("dbo.Application", "PGC_ID");
            DropColumn("dbo.Application", "Evaluator_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Application", "Evaluator_ID", c => c.Int());
            AddColumn("dbo.Application", "PGC_ID", c => c.Int());
            AddColumn("dbo.Application", "PGFO_ID", c => c.Int());
            AddColumn("dbo.Application", "PGO_ID", c => c.Int());
            CreateIndex("dbo.Application", "Evaluator_ID");
            CreateIndex("dbo.Application", "PGC_ID");
            CreateIndex("dbo.Application", "PGFO_ID");
            CreateIndex("dbo.Application", "PGO_ID");
            AddForeignKey("dbo.Application", "PGO_ID", "dbo.PGO", "PGO_ID");
            AddForeignKey("dbo.Application", "PGFO_ID", "dbo.PGFO", "PGFO_ID");
            AddForeignKey("dbo.Application", "PGC_ID", "dbo.PGC", "PGC_ID");
            AddForeignKey("dbo.Application", "Evaluator_ID", "dbo.Evaluator", "Evaluator_ID");
        }
    }
}
