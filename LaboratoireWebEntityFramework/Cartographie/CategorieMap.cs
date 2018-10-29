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
            ToTable("TB_CATEGORIE]");

            HasKey(x => x.Id);
            Property(x => x.NomCaregorie);
            Property(x => x.DateCreation);
            Property(x => x.Actif);
        }
    }
}