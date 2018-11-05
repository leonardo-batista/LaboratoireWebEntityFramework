using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Models.Class
{
    public class ClientSession
    {
        public Guid Id_Consommateur { get; set; }
        public DateTime? DateCreation { get; set; }

        public ClientSession()
        {

        }
    }
}