using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace MusacaMvcApp___Exam_18_Dec_2018.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse StyleCss(HttpRequest request)
        {
            return this.File("wwwroot/css/style.css", "text/css");
        }

        public HttpResponse ResetCss(HttpRequest request)
        {
            return this.File("wwwroot/css/reset-css.css", "text/css");
        }

        public HttpResponse BootstrapMinCss(HttpRequest request)
        {
            return this.File("wwwroot/css/bootstrap.min.css", "text/css");
        }
    }
}
