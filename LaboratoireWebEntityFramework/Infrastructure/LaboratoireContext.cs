using LaboratoireWebEntityFramework.Cartographie;
using LaboratoireWebEntityFramework.Models.Class;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace LaboratoireWebEntityFramework.Infrastructure
{
    public class LaboratoireContext : DbContext
    {
        public LaboratoireContext() : base("name=BD_LABORATOIRE")
        {

        }

        public DbSet<Categorie> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CategorieMap());
        }

    }
}