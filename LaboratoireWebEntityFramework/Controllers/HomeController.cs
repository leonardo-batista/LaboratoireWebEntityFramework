using LaboratoireWebEntityFramework.Filters;
using LaboratoireWebEntityFramework.Infrastructure;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;

namespace LaboratoireWebEntityFramework.Controllers
{
    [ComVisible(false)]
    [CacheResponse]
    [HandleExceptionAttribute]
    [EnableCompression]
    public class HomeController : Controller
    {
        //private JsonResult ThrowJsonError(Exception e)
        //{
        //    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        //    return Json(new { Message = e.Message }, JsonRequestBehavior.AllowGet);
        //}

        // GET: Home
        public ActionResult Index()
        {

            using (LaboratoireContext context = new LaboratoireContext())
            {
                var result = context.Categories.OrderBy(c => c.NomCaregorie).ToList();

                /*
                context.Categories.Add(new Models.Class.Categorie()
                {
                    NomCaregorie = "Test Leozao",
                    Actif = true,
                });

                context.SaveChanges();
                */
            }




            return View();
        }
    }
}