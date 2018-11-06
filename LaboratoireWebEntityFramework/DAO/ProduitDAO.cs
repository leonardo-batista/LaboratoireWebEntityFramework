using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models.Class;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.DAO
{
    public class ProduitDAO
    {
        private LaboratoireContext context;
        private ILog logger;

        public ProduitDAO(LaboratoireContext context, ILog logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Produit Detail(int idProduit)
        {
            try
            {
                logger.Info("Requête, Détail Produit");
                return context.Produits_.Where(prd => prd.Id_Produit == idProduit).FirstOrDefault<Produit>();
            }
            catch (IOException iOEx)
            {
                logger.Error("IOException ", iOEx);
                throw iOEx;
            }
            catch (SqlException sqlEx)
            {
                logger.Error("SqlException Base de Donnée", sqlEx);
                throw sqlEx;
            }
            catch (Exception ex)
            {
                logger.Error("Exception Générique", ex);
                throw ex;
            }
        }

        public List<Produit> ListeDeProduitParCategorie()
        {
            try
            {
                logger.Info("Requête, Liste de Produits");
                return context.Produits_.Where(prd => prd.Actif == true).OrderBy(prd => prd.NomProduit).ToList();
            }
            catch (IOException iOEx)
            {
                logger.Error("IOException ", iOEx);
                throw iOEx;
            }
            catch (SqlException sqlEx)
            {
                logger.Error("SqlException Base de Donnée", sqlEx);
                throw sqlEx;
            }
            catch (Exception ex)
            {
                logger.Error("Exception Générique", ex);
                throw ex;
            }
        }

        public List<Produit> ListeDeProduitParCategorie(int idCategorie)
        {
            try
            {
                logger.Info("Requête, Liste de Produits par Categorie: " + idCategorie);
                return context.Produits_.Where(prd => prd.Actif == true && prd.IdCategorie == idCategorie).OrderBy(prd => prd.NomProduit).ToList();
            }
            catch (IOException iOEx)
            {
                logger.Error("IOException ", iOEx);
                throw iOEx;
            }
            catch (SqlException sqlEx)
            {
                logger.Error("SqlException Base de Donnée", sqlEx);
                throw sqlEx;
            }
            catch (Exception ex)
            {
                logger.Error("Exception Générique", ex);
                throw ex;
            }
        }

    }
}