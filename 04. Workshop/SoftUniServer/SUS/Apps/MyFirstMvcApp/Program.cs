using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //02. we move the routeTable to the Startup clss in the My First Mvc App
            //List<Route> routeTable = new List<Route>();
            //routeTable.Add(new Route("/", new HomeController().Index));
            //routeTable.Add(new Route("/users/login", new UsersController().Login));
            //routeTable.Add(new Route("/users/register", new UsersController().Register));
            //routeTable.Add(new Route("/cards/all", new CardsController().All));
            //routeTable.Add(new Route("/cards/add", new CardsController().Add));
            //routeTable.Add(new Route("/cards/collection", new CardsController().Collection));

            //routeTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            //routeTable.Add(new Route("/css/bootstrap.min.css", new StaticFilesController().BootstrapCss));
            //routeTable.Add(new Route("/css/custom.css", new StaticFilesController().CustomCss));
            //routeTable.Add(new Route("/js/bootstrap.bundle.min.js", new StaticFilesController().BootstrapJs));
            //routeTable.Add(new Route("/js/custom.js", new StaticFilesController().CustomJs));

            //01. we create a class Route in MVC so that the start of the process can be done in the WebHost class
            //server.AddRoute("/", new HomeController().Index);
            //server.AddRoute("/deni", (request) =>
            //{
            //    return new HttpResponse("text/html", new byte[] { 0x56, 0x57 });
            //});
            //server.AddRoute("/favicon.ico", new StaticFilesController().FavIcon);
            //server.AddRoute("/users/login", new UsersController().Login);
            //server.AddRoute("/users/register", new UsersController().Register);
            //server.AddRoute("/cards/all", new CardsController().All);
            //server.AddRoute("/cards/add", new CardsController().Add);
            //server.AddRoute("/cards/collection", new CardsController().Collection);

            //we move these to start on the WebHost class
            //IHttpServer server = new HttpServer();
            //Process.Start(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "http://localhost");
            //await server.StartAsync(80);

            await WebHost.CreateHostAsync(new Startup(), 80);
        }
    }
}
