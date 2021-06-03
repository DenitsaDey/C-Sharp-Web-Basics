using MyWebServer.Server;
using MyWebServer.Server.Responses;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Startup
    {
        //public static async Task Main()
        //{
        //    // http://localhost:8080

        //    var server = new HttpServer("127.0.0.1", 8080);

        //    await server.Start();   
        //}
        // this goes to the shorter version down

        public static async Task Main()
         => await new HttpServer(
             routingTable=> routingTable
             .MapGet("/", new TextResponse("Hello from Deni!"))
             .MapGet("/Cats", new TextResponse("<h1>Hello from the cats!</h1>", "text/html"))
             .MapGet("/Dogs", new TextResponse("<h1>Hello from the dogs!</h1>", "text/html")))
            .Start();
    }
}
