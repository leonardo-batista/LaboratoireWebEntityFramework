using LaboratoireWebEntityFramework.DAO;
using LaboratoireWebEntityFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratoireWebEntityFramework.Filters
{
    public class ConsommateurSessionFilterAttribute : ActionFilterAttribute
    {
        private ConsommateurDAO consommateurDAO;
        //private LaboratoireContext context;
        //public ConsommateurSessionFilterAttribute(ConsommateurDAO consommateurDAO)
        //{
        //    this.consommateurDAO = consommateurDAO;
        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object idConsommateurSession = filterContext.RequestContext.HttpContext.Request.Cookies["idConsommateurSession"];

            if (idConsommateurSession == null)
            {
                consommateurDAO = new ConsommateurDAO();

                string resultatConsommateurSession = consommateurDAO.ConsommateurSessionID();

                HttpCookie cookie = new HttpCookie("idConsommateurSession");
                cookie.Value = resultatConsommateurSession;
                cookie.Expires = DateTime.Now.AddHours(24);
                filterContext.HttpContext.Response.AppendCookie(cookie);
            }
            else
            {
                //TODO! Verifier sur le cas d'expiration (Date).
            }
        }
    }
}