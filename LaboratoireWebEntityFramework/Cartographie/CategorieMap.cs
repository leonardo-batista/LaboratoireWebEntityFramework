using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Cartographie
{
    public class CategorieMap : EntityTypeConfiguration<Categorie>
    {
        public CategorieMap()
        {
            ToTable("TB_CATEGORIE");

            HasKey(cat => cat.Id);
            //Property(cat => cat.Id).HasColumnName("ID_CATEGORIE");

            Property(cat => cat.NomCaregorie).HasColumnName("NOM_CATEGORIE");
            Property(cat => cat.DateCreation).HasColumnName("DATE_CREATION");
            Property(cat => cat.Actif).HasColumnName("ACTIF");
        }
    }
}