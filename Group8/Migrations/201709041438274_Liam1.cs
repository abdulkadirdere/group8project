namespace Group8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Liam1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluator", "Evaluator_Password", c => c.String());
            AddColumn("dbo.PGC", "PGC_Password", c => c.String());
            AddColumn("dbo.PGFO", "PGFO_Password", c => c.String());
            AddColumn("dbo.PGO", "PGO_Password", c => c.String());
            AlterColumn("dbo.PGO", "PGO_First_Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PGO", "PGO_First_Name", c => c.String());
            DropColumn("dbo.PGO", "PGO_Password");
            DropColumn("dbo.PGFO", "PGFO_Password");
            DropColumn("dbo.PGC", "PGC_Password");
            DropColumn("dbo.Evaluator", "Evaluator_Password");
        }
    }
}
