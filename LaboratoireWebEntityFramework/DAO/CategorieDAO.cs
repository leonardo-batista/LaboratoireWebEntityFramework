using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaboratoireWebEntityFramework.DAO
{
    public class CategorieDAO
    {

        private LaboratoireContext context;

        public CategorieDAO(LaboratoireContext context)
        {
            this.context = context;
        }

        public List<Categorie> ListeDesCategories()
        {
            try
            {
                return context.Categories_.OrderBy(c => c.NomCaregorie).Where(c => c.Actif == true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}