using LaboratoireWebEntityFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Models.Class
{
    public class Produit : ITable
    {
        protected Int32 id;
        protected Int32 idCategorie;
        protected Int32 idMarque;
        protected string nomProduit = string.Empty;
        protected string description = string.Empty;
        protected string ficheTechnique = string.Empty;
        protected decimal valeur;
        protected string sku = string.Empty;
        protected DateTime? dateCreation;
        protected bool actif;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Int32 IdCategorie
        {
            get { return this.idCategorie; }
            set { this.idCategorie = value; }
        }

        public Int32 IdMarque
        {
            get { return this.idMarque; }
            set { this.idMarque = value; }
        }

        public string NomProduit
        {
            get { return this.nomProduit; }
            set { this.nomProduit = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string FicheTechnique
        {
            get { return this.ficheTechnique; }
            set { this.ficheTechnique = value; }
        }

        public decimal Valeur
        {
            get { return this.valeur; }
            set { this.valeur = value; }
        }

        public string Sku
        {
            get { return this.sku; }
            set { this.sku = value; }
        }

        public bool Actif
        {
            get { return this.actif; }
            set { this.actif = value; }
        }

        public DateTime? DateCreation
        {
            get { return this.dateCreation; }
            set { this.dateCreation = value; }
        }


        public Produit()
        {

        }
    }
}