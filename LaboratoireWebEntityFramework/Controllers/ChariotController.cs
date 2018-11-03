using LaboratoireWebEntityFramework.DAO;
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

    }
}