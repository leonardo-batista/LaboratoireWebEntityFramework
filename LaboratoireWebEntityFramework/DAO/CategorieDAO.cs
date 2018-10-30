using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models.Class;
using LaboratoireWebEntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.DAO
{
    public class CategorieDAO
    {
        //private IRepositoryContext<Categorie> repository;

        //public CategorieDAO(RepositoryContext<Categorie> repository)
        //{
        //    this.repository = repository;
        //}

        private LaboratoireContext repository;

        public CategorieDAO(LaboratoireContext repository)
        {
            this.repository = repository;
        }

        public void CreateCategorie()
        {
            try
            {
                //repository.InsertModel(new Categorie
                //{
                //    NomCaregorie = "sdfasdfsdf"
                //    , Actif = true
                //});

                repository.Categories.Add(new Categorie
                {
                    NomCaregorie = "xxxxx"
                    , Actif = true
                });

                repository.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}