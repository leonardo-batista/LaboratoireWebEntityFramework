using LaboratoireWebEntityFramework.Models.Class;
using LaboratoireWebEntityFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Models
{
    public class Chariot 
    {
        //COLUMN SQL SERVER BIG INT its necessary to work with INT64
        public Int64 IdChariot { get; set; }
        public Int32 IdProduit { get; set; }
        public Guid IdConsommateur { get; set; }
        public int Quantite { get; set; }
        public decimal ValeurUnitaire { get; set; }
        public decimal ValeurTotalArticle { get { return Quantite * ValeurUnitaire; }  set { } }
        public DateTime? DateCreation { get; set; }
        public bool Actif { get; set; }
        public virtual Produit Produit { get; set; }

        public Chariot()
        {
            this.IdConsommateur = new Guid();
        }
    }
}