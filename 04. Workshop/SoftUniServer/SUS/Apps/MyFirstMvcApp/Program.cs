using SUS.HTTP;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            
            server.AddRoute("/", HomePage);
            server.AddRoute("/deni", (request) =>
            {
                return new HttpResponse("text/html", new byte[] { 0x56, 0x57 });
            });
            server.AddRoute("/favicon.ico", FavIcon);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);

            Process.Start(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "http://localhost");
            await server.StartAsync(80);
        }


        static HttpResponse HomePage(HttpRequest request)
        {
            var responseHtml = "<h1>Welcome!</h1>" +
                request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }
        static HttpResponse FavIcon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);
            return response;
        }

        static HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>About...</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }
        static HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>Login...</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }
    }
}
