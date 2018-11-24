using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEntityFramework.Tests.Class
{
    public class Produit
    {
        public Int32 IdProduit { get; set; }
        public Int32 IdCategorie { get; set; }
        public Int32 IdMarque { get; set; }
        public string NomProduit { get; set; }
        public string Description { get; set; }
        public string FicheTechnique { get; set; }
        public decimal Valeur { get; set; }
        public string Sku { get; set; }
        public DateTime? DateCreation { get; set; }
        public bool Actif { get; set; }
    }
}
