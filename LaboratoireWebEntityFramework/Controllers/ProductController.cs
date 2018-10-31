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
    public class ProductController : Controller
    {
        private ProduitDAO produitDAO;
        private CategorieDAO categorieDAO;

        public ProductController(ProduitDAO produitDAO, CategorieDAO categorieDAO)
        {
            this.produitDAO = produitDAO;
            this.categorieDAO = categorieDAO;
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
        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Server)]
        public JsonResult ListeCategorieProduit()
        {
            try
            {
                return Json(new
                {
                    dataResult = categorieDAO.ListeDesCategories()
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpGet]
        public JsonResult ProductDetail(int idProduct)
        {
            try
            {
                return Json(new
                {
                    dataResult = produitDAO.Detail(idProduct)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpGet]
        public JsonResult ListeDeProduitsParCategorieTous()
        {
            try
            {
                return Json(new
                {
                    dataResult = produitDAO.ListeDeProduitParCategorie()
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpGet]
        public JsonResult ListeDeProduitsParCategorie(int idCategorie)
        {
            try
            {
                return Json(new
                {
                    dataResult = produitDAO.ListeDeProduitParCategorie(idCategorie)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

    }
}