using MyWebServer.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Program
    {
        public static async Task Main()
        {
            // http://localhost:8080

            var server = new HttpServer("127.0.0.1", 8080);

            await server.Start();

            
        }
    }
}
