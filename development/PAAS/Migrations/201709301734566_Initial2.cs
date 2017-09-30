namespace PAAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Application", new[] { "PGO_ID" });
            DropIndex("dbo.Application", new[] { "PGFO_ID" });
            DropIndex("dbo.Application", new[] { "PGC_ID" });
            DropIndex("dbo.Application", new[] { "Evaluator_ID" });
            AlterColumn("dbo.Application", "PGO_ID", c => c.Int());
            AlterColumn("dbo.Application", "PGFO_ID", c => c.Int());
            AlterColumn("dbo.Application", "PGC_ID", c => c.Int());
            AlterColumn("dbo.Application", "Evaluator_ID", c => c.Int());
            CreateIndex("dbo.Application", "PGO_ID");
            CreateIndex("dbo.Application", "PGFO_ID");
            CreateIndex("dbo.Application", "PGC_ID");
            CreateIndex("dbo.Application", "Evaluator_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Application", new[] { "Evaluator_ID" });
            DropIndex("dbo.Application", new[] { "PGC_ID" });
            DropIndex("dbo.Application", new[] { "PGFO_ID" });
            DropIndex("dbo.Application", new[] { "PGO_ID" });
            AlterColumn("dbo.Application", "Evaluator_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Application", "PGC_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Application", "PGFO_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Application", "PGO_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Application", "Evaluator_ID");
            CreateIndex("dbo.Application", "PGC_ID");
            CreateIndex("dbo.Application", "PGFO_ID");
            CreateIndex("dbo.Application", "PGO_ID");
        }
    }
}
