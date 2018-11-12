using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireWebEntityFramework.Tests.Outils
{
    public class BusinessMessage
    {
        private string businessCode = string.Empty;
        private string businessDescription = string.Empty;

        public string BusinessCode
        {
            get { return this.businessCode; }
            set { this.businessCode = value; }
        }

        public string BusinessDescription
        {
            get { return this.businessDescription; }
            set { this.businessDescription = value; }
        }

        public BusinessMessage()
        {

        }
    }
}
