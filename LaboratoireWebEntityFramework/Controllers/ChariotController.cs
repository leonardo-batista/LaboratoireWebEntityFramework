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
        // GET: Chariot
        public ActionResult Index()
        {
            return View();
        }
    }
}