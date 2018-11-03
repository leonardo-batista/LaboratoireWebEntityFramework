using LaboratoireWebEntityFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Models.Class
{
    public class Produit
    {
        public Int32 Id_Produit { get; set; }
        public Int32 IdCategorie { get; set; }
        public Int32 IdMarque { get; set; }
        public string NomProduit { get; set; }
        public string Description { get; set; }
        public string FicheTechnique { get; set; }
        public decimal Valeur { get; set; }
        public string Sku { get; set; }
        public DateTime? DateCreation { get; set; }
        public bool Actif { get; set; }

        //public virtual ICollection<Chariot> Chariots { get; set; }

        

        //public Int32 Id
        //{
        //    get { return this.id; }
        //    set { this.id = value; }
        //}

        //public Int32 IdCategorie
        //{
        //    get { return this.idCategorie; }
        //    set { this.idCategorie = value; }
        //}

        //public Int32 IdMarque
        //{
        //    get { return this.idMarque; }
        //    set { this.idMarque = value; }
        //}

        //public string NomProduit
        //{
        //    get { return this.nomProduit; }
        //    set { this.nomProduit = value; }
        //}

        //public string Description
        //{
        //    get { return this.description; }
        //    set { this.description = value; }
        //}

        //public string FicheTechnique
        //{
        //    get { return this.ficheTechnique; }
        //    set { this.ficheTechnique = value; }
        //}

        //public decimal Valeur
        //{
        //    get { return this.valeur; }
        //    set { this.valeur = value; }
        //}

        //public string Sku
        //{
        //    get { return this.sku; }
        //    set { this.sku = value; }
        //}

        //public bool Actif
        //{
        //    get { return this.actif; }
        //    set { this.actif = value; }
        //}

        //public DateTime? DateCreation
        //{
        //    get { return this.dateCreation; }
        //    set { this.dateCreation = value; }
        //}

        public Produit()
        {
            
        }
    }
}