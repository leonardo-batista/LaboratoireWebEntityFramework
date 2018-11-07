using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Cartographie
{
    public class ClientSessionMap : EntityTypeConfiguration<ClientSession>
    {
        public ClientSessionMap()
        {
            ToTable("TB_CLIENT_SESSION");

            HasKey(ssc => ssc.Id_Consommateur);
            Property(ssc => ssc.Id_Consommateur).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID_CONSOMMATEUR");
            Property(ssc => ssc.DateCreation).HasColumnName("DATE_CREATION").IsOptional().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}