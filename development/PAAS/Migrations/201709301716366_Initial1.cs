namespace PAAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Interview", "PGC_PGC_ID", "dbo.PGC");
            DropIndex("dbo.Interview", new[] { "PGC_PGC_ID" });
            DropColumn("dbo.Interview", "PGC_PGC_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interview", "PGC_PGC_ID", c => c.Int());
            CreateIndex("dbo.Interview", "PGC_PGC_ID");
            AddForeignKey("dbo.Interview", "PGC_PGC_ID", "dbo.PGC", "PGC_ID");
        }
    }
}
