using LaboratoireWebEntityFramework.DAO;
using LaboratoireWebEntityFramework.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LaboratoireWebEntityFramework.Controllers
{
    [ComVisible(false)]
    [CacheResponse]
    [HandleExceptionAttribute]
    [EnableCompression]
    [ConsommateurSessionFilterAttribute]
    public class ChariotController : Controller
    {
        private ChariotDAO chariotDAO;

        public ChariotController(ChariotDAO chariotDAO)
        {
            this.chariotDAO = chariotDAO;
        }

        private JsonResult ThrowJsonError(Exception e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            return Json(new { Message = e.Message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "idConsommateur", Location = OutputCacheLocation.Server)]
        public JsonResult ChariotConsommateur(string idConsommateur)
        {
            try
            {
                return Json(new
                {
                    dataResult = chariotDAO.ChariotConsummateur(idConsommateur)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpPost]
        public JsonResult ChariotConsommateurAjouterProduit(string idConsommateur, Int32 idProduit)
        {
            try
            {
                var urlToRemove = Url.Action("ChariotConsommateur", "Chariot");
                HttpResponse.RemoveOutputCacheItem(urlToRemove);

                return Json(new
                {
                    dataResult = chariotDAO.ChariotAjouterProduit(idConsommateur, idProduit)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpPost]
        public JsonResult ChariotConsommateurMiseAJourQuantite(string idConsommateur, Int32 idProduit, int quantite)
        {
            try
            {
                var urlToRemove = Url.Action("ChariotConsommateur", "Chariot");
                HttpResponse.RemoveOutputCacheItem(urlToRemove);

                return Json(new
                {
                    dataResult = chariotDAO.ChariotMiseAjourQuantite(idConsommateur, idProduit, quantite)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpDelete]
        public JsonResult ChariotConsommateurSupprimerProduit(string idConsommateur, Int32 idProduit)
        {
            try
            {
                var urlToRemove = Url.Action("ChariotConsommateur", "Chariot");
                HttpResponse.RemoveOutputCacheItem(urlToRemove);
                return Json(new
                {
                    dataResult = chariotDAO.ChariotSupprimerProduit(idConsommateur, idProduit)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }
    }
}