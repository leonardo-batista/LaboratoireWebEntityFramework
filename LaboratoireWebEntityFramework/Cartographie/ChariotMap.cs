using LaboratoireWebEntityFramework.Models;
using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Cartographie
{
    public class ChariotMap : EntityTypeConfiguration<Chariot>
    {
        public ChariotMap()
        {
            ToTable("TB_CHARIOT_TEMP");

            HasKey(cha => cha.Id_Chariot);
            //Property(cha => cha.IdChariot).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID_CHARIOT");
            Property(cha => cha.IdConsommateur).HasColumnName("ID_CONSOMMATEUR").HasColumnType("uniqueidentifier");
            Property(cha => cha.Id_Produit).HasColumnName("ID_PRODUIT");
            Property(cha => cha.Quantite).HasColumnName("QUANTITE");
            Property(cha => cha.ValeurUnitaire).HasColumnName("VALEUR_UNITAIRE");
            Property(cha => cha.ValeurTotalArticle).HasColumnName("VALEUR_TOTAL_ARTICLE");
            Property(cha => cha.DateCreation).HasColumnName("DATE_CREATION").IsOptional().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(cha => cha.Actif).HasColumnName("ACTIF");            
        }
    }
}