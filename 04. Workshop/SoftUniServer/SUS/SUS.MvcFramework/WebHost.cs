using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class WebHost
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);
            
            IHttpServer server = new HttpServer(routeTable);

            
            Process.Start(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "http://localhost");
            await server.StartAsync(port);
        }
    }
}
