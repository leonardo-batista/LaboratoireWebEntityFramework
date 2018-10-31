using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Cartographie
{
    public class ProduitMap : EntityTypeConfiguration<Produit>
    {
        public ProduitMap()
        {
            ToTable("TB_PRODUIT");

            Property(prd => prd.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID_PRODUIT");
            Property(prd => prd.IdCategorie).HasColumnName("ID_CATEGORIE");
            Property(prd => prd.IdMarque).HasColumnName("ID_MARQUE");
            Property(prd => prd.NomProduit).HasColumnName("NOM_PRODUIT");
            Property(prd => prd.Description).HasColumnName("DESCRIPTION");
            Property(prd => prd.FicheTechnique).HasColumnName("FICHE_TECHNIQUE");
            Property(prd => prd.DateCreation).HasColumnName("DATE_CREATION").IsOptional().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(prd => prd.Actif).HasColumnName("ACTIF");
        }
    }
}