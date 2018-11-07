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

        public bool ChariotAjouterProduit(string idConsommateur, Int32 idProduit)
        {
            try
            {
                logger.Info("Requête, Liste des Produits du Consommateur");
                var resultat = (from p in context.Chariots_
                                where p.IdConsommateur == new Guid(idConsommateur) && p.Id_Produit == idProduit
                                select p).SingleOrDefault();

                if (resultat != null)
                {
                    resultat.Quantite += 1;
                    resultat.ValeurUnitaire = resultat.Produit.Valeur;
                    resultat.ValeurTotalArticle = resultat.Produit.Valeur * resultat.Quantite;

                    logger.Info("SaveChagens(), Consommateur a changé la quantité des produits");
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    logger.Info("Requetê, Verifiér si il y a de Produit avant de Ajouter au Chariot/Panner, SessionConsommateur: " + idConsommateur);
                    var restultatProduit = (from p in context.Produits_
                                            where p.Id_Produit == idProduit
                                            select p).SingleOrDefault();

                    if (restultatProduit != null)
                    {
                        Chariot chariot = new Chariot();
                        chariot.IdConsommateur = new Guid(idConsommateur);
                        chariot.Id_Produit = restultatProduit.Id_Produit;
                        chariot.ValeurUnitaire = restultatProduit.Valeur;
                        chariot.ValeurTotalArticle = restultatProduit.Valeur * 1;
                        chariot.Quantite = 1;
                        chariot.Actif = true;

                        context.Chariots_.Add(chariot);
                        context.SaveChanges();
                        logger.Info("SaveChagens(), Consommateur a ajouté le Produit, Session: " + idConsommateur);

                        return true;
                    }
                    else
                    {
                        logger.Info("Ooopps, Pas de Produit pour le Consommateur ajouter, Session: " + idConsommateur);
                        return false;
                    }
                }                
            }
            catch (IOException iOEx)
            {
                logger.Error("IOException ", iOEx);
                throw iOEx;
            }
            catch (SqlException sqlEx)
            {
                logger.Fatal("SqlException Base de Donnée", sqlEx);
                throw sqlEx;
            }
            catch (Exception ex)
            {
                logger.Error("Exception Générique", ex);
                throw ex;
            }
        }

        public bool ChariotMiseAjourQuantite(string idConsommateur, Int32 idProduit, int quantite)
        {
            try
            {
                logger.Info("Requête, Liste des Produits du Consommateur");
                var resultat = (from p in context.Chariots_
                                where p.IdConsommateur == new Guid(idConsommateur) && p.Id_Produit == idProduit
                                select p).SingleOrDefault();

                if (resultat != null)
                {
                    resultat.Quantite = quantite;
                    context.SaveChanges();
                    logger.Info("SaveChagens(), Consommateur faire la mise à jour, Session: " + idConsommateur);

                    return true;
                }
                else
                {
                    logger.Info("Ooopps, Pas de Produit pour le Consommateur faire la mise à jour, Session: " + idConsommateur);
                    return false;
                }               
            }
            catch (IOException iOEx)
            {
                logger.Error("IOException ", iOEx);
                throw iOEx;
            }
            catch (SqlException sqlEx)
            {
                logger.Fatal("SqlException Base de Donnée", sqlEx);
                throw sqlEx;
            }
            catch (Exception ex)
            {
                logger.Error("Exception Générique", ex);
                throw ex;
            }
        }

        public bool ChariotSupprimerProduit(string idConsommateur, Int32 idProduit)
        {
            try
            {
                logger.Info("Requête, Liste des Produits du Consommateur, Session: " + idConsommateur);
                var resultat = (from p in context.Chariots_
                                where p.IdConsommateur == new Guid(idConsommateur) && p.Id_Produit == idProduit
                                select p).SingleOrDefault();

                if (resultat != null)
                {
                    context.Chariots_.Remove(resultat);
                    context.SaveChanges();
                    logger.Info("Supprimer, Le Consommateur a supprimé le produit, Session: " + idConsommateur);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (IOException iOEx)
            {
                logger.Error("IOException ", iOEx);
                throw iOEx;
            }
            catch (SqlException sqlEx)
            {
                logger.Fatal("SqlException Base de Donnée", sqlEx);
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