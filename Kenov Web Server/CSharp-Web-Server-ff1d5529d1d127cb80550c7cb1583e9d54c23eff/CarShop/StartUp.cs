﻿using System.Threading.Tasks;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

namespace CarShop
{
    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>())
                .Start();
    }
}
