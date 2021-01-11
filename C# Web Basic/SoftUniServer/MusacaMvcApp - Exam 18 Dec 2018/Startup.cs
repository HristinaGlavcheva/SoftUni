using MusacaMvcApp___Exam_18_Dec_2018.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace MusacaMvcApp___Exam_18_Dec_2018
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
        }

        public void Configure(List<Route> routeTable)
        {
            routeTable.Add(new Route("/home/index", HttpMethod.Get, new HomeController().Index));
            routeTable.Add(new Route("/users/login", HttpMethod.Get, new UsersController().Login));
            routeTable.Add(new Route("/users/register", HttpMethod.Get, new UsersController().Register));


            routeTable.Add(new Route("/css/style.css", HttpMethod.Get, new StaticFilesController().StyleCss));
            routeTable.Add(new Route("/css/reset-css.css", HttpMethod.Get, new StaticFilesController().ResetCss));
            routeTable.Add(new Route("/css/bootstrap.min.css", HttpMethod.Get, new StaticFilesController().BootstrapMinCss));
        }
    }
}