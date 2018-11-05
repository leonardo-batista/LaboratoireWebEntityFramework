using LaboratoireWebEntityFramework.Cartographie;
using LaboratoireWebEntityFramework.Models;
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

        public DbSet<ClientSession> ClientSessions_ { get; set; }
        public DbSet<Chariot> Chariots_ { get; set; }
        public DbSet<Categorie> Categories_ { get; set; }
        public DbSet<Produit> Produits_ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("LABORATOIRE");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClientSessionMap());
            modelBuilder.Configurations.Add(new ChariotMap());
            modelBuilder.Configurations.Add(new CategorieMap());
            modelBuilder.Configurations.Add(new ProduitMap());
        }

    }
}