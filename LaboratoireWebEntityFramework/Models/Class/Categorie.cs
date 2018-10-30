using LaboratoireWebEntityFramework.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Models.Class
{
    public class Categorie : ITable
    {
        protected Int32 id;
        protected DateTime? dateCreation;
        protected bool actif;
        protected string nomCaregorie = string.Empty;

        public Int32 Id
        {
            get { return this.id; }
            set { this.id = value; }
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