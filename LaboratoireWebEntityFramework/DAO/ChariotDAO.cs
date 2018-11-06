using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.DAO
{
    public class ChariotDAO
    {
        private LaboratoireContext context;
        private ILog logger;

        public ChariotDAO(LaboratoireContext context, ILog logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public List<Chariot> ChariotConsummateur(string idConsommateur)
        {
            try
            {

                //TODO! Alors, les deux options ci-dessous ça marche très bien ;) 

                //1er Option de Requete
                logger.Info("Requête, Liste des Produits du Consommateur");
                return context.Chariots_.Include("Produit").OrderBy(cha => cha.DateCreation).Where(cha => cha.IdConsommateur == new Guid(idConsommateur)).ToList();

                //2eme Option de Requete
                //var lista = (from p in context.Chariots_.Include("Produit")
                //             where p.IdConsommateur == new Guid(idConsommateur)
                //             select p).ToList();

                //return lista;
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