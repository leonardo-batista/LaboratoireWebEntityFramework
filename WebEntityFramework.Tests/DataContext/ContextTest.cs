using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEntityFramework.Tests.Cartographie;
using WebEntityFramework.Tests.Class;
using WebEntityFramework.Tests.Interface;

namespace WebEntityFramework.Tests.DataContext
{
    public class ContextTest : DbContext, IContext
    {
        public ContextTest() : base("name=BD_LABORATOIRE_TESTE")
        {
            //FR = DÉSACTIVER LA CREÁTION AUTOMATIQUE DE LA BASE DE DONNÉE - US = DISABLE DATABASE INITIALIZER
            Database.SetInitializer<ContextTest>(null);
        }

        public IDbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ProduitMap());
        }
    }
}
