using LaboratoireWebEntityFramework.Tests.Affaire;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireWebEntityFramework.Tests
{
    [TestClass]
    public class ProduitTest
    {
        private ProduitAffaire produitAffaire;

        public ProduitTest()
        {
            produitAffaire = new ProduitAffaire();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProduitCodeArgumentNullException()
        {
            produitAffaire.ProduitCode("");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ProduitCodeFormatException()
        {
            produitAffaire.ProduitCode("x");
        }

        [TestMethod]
        public void ProduitCodeReussi()
        {
            produitAffaire.ProduitCode("1");
        }

    }
}
