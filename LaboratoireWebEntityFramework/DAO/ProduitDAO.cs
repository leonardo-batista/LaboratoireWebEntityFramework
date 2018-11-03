using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.DAO
{
    public class ProduitDAO
    {
        private LaboratoireContext context;

        public ProduitDAO(LaboratoireContext context)
        {
            this.context = context;
        }

        public Produit Detail(int idProduit)
        {
            try
            {
                return context.Produits_.Where(prd => prd.Id_Produit == idProduit).FirstOrDefault<Produit>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produit> ListeDeProduitParCategorie()
        {
            try
            {
                return context.Produits_.Where(prd => prd.Actif == true).OrderBy(prd => prd.NomProduit).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produit> ListeDeProduitParCategorie(int idCategorie)
        {
            try
            {
                return context.Produits_.Where(prd => prd.Actif == true && prd.IdCategorie == idCategorie).OrderBy(prd => prd.NomProduit).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}