using LaboratoireWebEntityFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Models.Class
{
    public class Categorie : ITable
    {
        protected UInt64 idCategorie;
        protected DateTime? dateCreation;
        protected bool actif;
        protected string nomCaregorie = string.Empty;
        

        public UInt64 Id
        {
            get { return this.idCategorie; }
            set { this.idCategorie = value; }
        }

        public DateTime? DateCreation
        {
            get { return this.dateCreation; }
            set { this.dateCreation = value; }
        }

        public bool Actif
        {
            get { return this.actif; }
            set { this.actif = value; }
        }

        public string NomCaregorie
        {
            get { return this.nomCaregorie; }
            set { this.nomCaregorie = value; }
        }

        public Categorie()
        {

        }
    }
}