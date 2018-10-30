using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

            Property(cat => cat.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID_CATEGORIE");
            Property(cat => cat.NomCaregorie).HasColumnName("NOM_CATEGORIE");
            Property(cat => cat.DateCreation).HasColumnName("DATE_CREATION").IsOptional().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(cat => cat.Actif).HasColumnName("ACTIF");
        }
    }
}