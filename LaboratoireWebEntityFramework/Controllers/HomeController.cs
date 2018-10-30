using LaboratoireWebEntityFramework.DAO;
using LaboratoireWebEntityFramework.Filters;
using LaboratoireWebEntityFramework.Infrastructure;
using LaboratoireWebEntityFramework.Models.Class;
using LaboratoireWebEntityFramework.Repository;
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
        //ça marcbe très bien
        //private LaboratoireContext context;

        //ça marcbe très bien
        //public HomeController(LaboratoireContext context)
        //{
        //    this.context = context;
        //}


        //private IRepositoryContext<Categorie> interfaceContext;

        //public HomeController(RepositoryContext<Categorie> context)
        //{
        //    interfaceContext = context;
        //}


        //private JsonResult ThrowJsonError(Exception e)
        //{
        //    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        //    return Json(new { Message = e.Message }, JsonRequestBehavior.AllowGet);
        //}

        private CategorieDAO categorieDAO;

        public HomeController(CategorieDAO categorieDAO)
        {
            this.categorieDAO = categorieDAO;
        }

        // GET: Home
        public ActionResult Index()
        {

            //CategorieDAO categorieDAO = new CategorieDAO();

            //cate

            categorieDAO.CreateCategorie();

            //var result = context.Categories.OrderBy(c => c.NomCaregorie).ToList();

            //var result = interfaceContext.List().OrderBy(c => c.NomCaregorie);

            //using (LaboratoireContext context = new LaboratoireContext())
            //{
            //    var result = context.Categories.OrderBy(c => c.NomCaregorie).ToList();

            //    /*
            //    context.Categories.Add(new Models.Class.Categorie()
            //    {
            //        NomCaregorie = "Test Leozao",
            //        Actif = true,
            //    });

            //    context.SaveChanges();
            //    */
            //}

            return View();
        }
    }
}