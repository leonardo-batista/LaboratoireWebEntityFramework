using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Web.Mvc;

namespace LaboratoireWebEntityFramework.Filters
{
    [ComVisible(false)]
    public class EnableCompressionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;

            string acceptEncoding = request.Headers["Accept-Encoding"].ToLower();

            if (string.IsNullOrEmpty(acceptEncoding)) return;

            if (acceptEncoding.Contains("gzip"))
            {
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                response.AppendHeader("Content-Encoding", "gzip");
            }
            else if (acceptEncoding.Contains("deflate"))
            {
                response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                response.AppendHeader("Content-Encoding", "deflate");
            }
        }
    }
}