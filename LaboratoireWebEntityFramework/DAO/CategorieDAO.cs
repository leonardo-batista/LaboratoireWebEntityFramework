using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models.Class;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace LaboratoireWebEntityFramework.DAO
{
    public class CategorieDAO
    {
        private LaboratoireContext context;
        private ILog logger;

        public CategorieDAO(LaboratoireContext context, ILog logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public List<Categorie> ListeDesCategories()
        {
            try
            {
                logger.Info("Requête, Liste de Categories");
                return context.Categories.OrderBy(c => c.NomCaregorie).Where(c => c.Actif == true).ToList();
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