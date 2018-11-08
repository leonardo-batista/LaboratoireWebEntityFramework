using LaboratoireWebEntityFramework.DAO;
using System;
using System.Web;
using System.Web.Mvc;

namespace LaboratoireWebEntityFramework.Filters
{
    public class ConsommateurSessionFilterAttribute : ActionFilterAttribute
    {
        private ConsommateurDAO consommateurDAO;
        //TODO! Utiliser l'injection de dépendance dans les filtres ?
        //private LaboratoireContext context;
        //public ConsommateurSessionFilterAttribute(ConsommateurDAO consommateurDAO)
        //{
        //    this.consommateurDAO = consommateurDAO;
        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object idConsommateurSession = filterContext.RequestContext.HttpContext.Request.Cookies["idConsommateurSession"];
            object chariotConsommateurProduit = filterContext.RequestContext.HttpContext.Request.Cookies["chariotConsommateurProduit"];
            ValidationSessionConsommateur(filterContext, idConsommateurSession, chariotConsommateurProduit);
        }

        private void ValidationSessionConsommateur(ActionExecutingContext filterContext, object idConsommateurSession, object chariotConsommateurProduit)
        {
            //TODO! Cas de Cookie expired....
            if (idConsommateurSession == null)
            {
                consommateurDAO = new ConsommateurDAO();

                string resultatConsommateurSession = consommateurDAO.ConsommateurSessionID();

                HttpCookie cookie = new HttpCookie("idConsommateurSession");
                cookie.Value = resultatConsommateurSession;
                cookie.Expires = DateTime.Now.AddHours(24);
                filterContext.HttpContext.Response.AppendCookie(cookie);

                HttpCookie cookieChariot = new HttpCookie("chariotConsommateurProduit");
                cookieChariot.Value = null;
                cookieChariot.Expires = DateTime.Now.AddHours(24);
                filterContext.HttpContext.Response.AppendCookie(cookieChariot);
            }
        }
    }
}