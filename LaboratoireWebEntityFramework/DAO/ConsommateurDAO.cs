using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.DAO
{

    public class ConsommateurDAO
    {
        private LaboratoireContext context =  new LaboratoireContext();

        //public ConsommateurDAO(LaboratoireContext context)
        //{
        //    this.context = context;
        //}

        public string ConsommateurSessionID()
        {
            try
            {
                ClientSession clientSession = new ClientSession();
                context.ClientSessions_.Add(clientSession);
                context.SaveChanges();
                return clientSession.Id_Consommateur.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}