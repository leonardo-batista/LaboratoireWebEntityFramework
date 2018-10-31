using LaboratoireWebEntityFramework.DAO;
using LaboratoireWebEntityFramework.Filters;
using LaboratoireWebEntityFramework.Models.Class;
using LaboratoireWebEntityFramework.Repository;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web.UI;

namespace LaboratoireWebEntityFramework.Controllers
{
    [ComVisible(false)]
    [CacheResponse]
    [HandleExceptionAttribute]
    [EnableCompression]
    public class HomeController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            return View();
        }
    }
}