using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireWebEntityFramework.Tests.Affaire
{

    public class ProduitAffaire
    {
        public void ProduitCode(string codeProduit)
        {
            if (string.IsNullOrEmpty(codeProduit))
            {
                throw new ArgumentNullException("codeProduit");
            }

            int resultatConvertion = Convert.ToInt32(codeProduit);
        }
    }
}
