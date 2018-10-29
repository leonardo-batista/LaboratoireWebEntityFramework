using LaboratoireWebEntityFramework.Cartographie;
using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

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