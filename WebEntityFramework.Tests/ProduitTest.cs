using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebEntityFramework.Tests.DataContext;

namespace WebEntityFramework.Tests
{
    [TestClass]
    public class ProduitTest
    {
        private ContextTest contextTest;

        public ProduitTest()
        {
            contextTest = new ContextTest();

        }



        [TestMethod]
        public void ProduitEnregistrer()
        {
            var resultat = contextTest.Produits.Add(new Class.Produit
            {
                Actif = true,
                Description = "Description TDD",
                FicheTechnique = "Les details du TDD",
                IdCategorie = 1,
                IdMarque = 1,
                NomProduit = "Neuf Produit " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                Valeur = 1
            });

            contextTest.SaveChanges();
            
            Assert.IsNotNull(resultat);
        }

        [TestCleanup]
        public void Nettoyage()
        {
            contextTest.Dispose();
        }
    }
}
