using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.DAO
{
    public class ChariotDAO
    {
        private LaboratoireContext context;

        public ChariotDAO(LaboratoireContext context)
        {
            this.context = context;
        }

        public List<Chariot> ChariotConsummateur(string idConsommateur)
        {
            try
            {
                
                //TODO! Alors, les deux options ci-dessous ça marche très bien ;) 

                //1er Option de Requete
                return context.Chariots_.Include("Produit").OrderBy(cha => cha.DateCreation).Where(cha => cha.IdConsommateur == new Guid(idConsommateur)).ToList();

                //2eme Option de Requete
                //var lista = (from p in context.Chariots_.Include("Produit")
                //             where p.IdConsommateur == new Guid(idConsommateur)
                //             select p).ToList();

                //return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}