using LaboratoireWebEntityFramework.DAO;
using LaboratoireWebEntityFramework.Filters;
using LaboratoireWebEntityFramework.Models.Class;
using LaboratoireWebEntityFramework.Repository;
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
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}