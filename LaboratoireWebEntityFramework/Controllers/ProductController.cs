using LaboratoireWebEntityFramework.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace LaboratoireWebEntityFramework.Controllers
{
    [ComVisible(false)]
    [CacheResponse]
    [HandleExceptionAttribute]
    [EnableCompression]
    public class ProductController : Controller
    {
        private JsonResult ThrowJsonError(Exception e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            return Json(new { Message = e.Message }, JsonRequestBehavior.AllowGet);
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListeCategorieProduit()
        {
            try
            {

            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }

            return Json(new
            {
                dataResult = ""
            }, JsonRequestBehavior.AllowGet);
        }


    }
}