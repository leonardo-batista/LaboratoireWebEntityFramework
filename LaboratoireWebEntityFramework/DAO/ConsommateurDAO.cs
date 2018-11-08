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

    public class ConsommateurDAO
    {
        private LaboratoireContext context =  new LaboratoireContext();
        private ILog logger = log4net.LogManager.GetLogger("LoggerEcommerce");
        //public ConsommateurDAO(LaboratoireContext context)
        //{
        //    this.context = context;
        //}

        public string ConsommateurSessionID()
        {
            try
            {
                logger.Info("Debut - Creátion de Session du Consommateur....");
                ClientSession clientSession = new ClientSession();
                context.ClientSessions.Add(clientSession);
                context.SaveChanges();
                logger.Info("Fin - Creátion de Session du Consommateur: " + clientSession.Id_Consommateur.ToString());
                return clientSession.Id_Consommateur.ToString();
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