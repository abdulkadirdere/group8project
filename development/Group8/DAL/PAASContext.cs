using Group8.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Group8.DAL
{
    public class PAASContext : DbContext
    {

        public PAASContext() : base("PAASContext")
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<PGO> PGOs { get; set; }
        public DbSet<PGC> PGCs { get; set; }
        public DbSet<PGFO> PGFOs { get; set; }
        public DbSet<Evaluator> Evaluators { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PAASContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}