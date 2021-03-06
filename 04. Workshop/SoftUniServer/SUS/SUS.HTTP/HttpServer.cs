using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        ICollection<Route> routeTable;

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
        }
        

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            try
            {
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    //TODO: research faster data structure for arrray of bytes
                    int position = 0;
                    byte[] buffer = new byte[HttpConstants.BufferSize];
                    List<byte> data = new List<byte>();

                    while (true)
                    {
                        int count = await stream.ReadAsync(buffer, position, buffer.Length);
                        position += count;

                        if (count < buffer.Length)
                        {
                            var partialBuffer = new byte[count];
                            Array.Copy(buffer, partialBuffer, count);
                            data.AddRange(partialBuffer);
                            break;
                        }
                        else
                        {
                            data.AddRange(buffer);
                        }

                    }

                    //byte[] => string (text) is called Encoding
                    var requestAsString = Encoding.UTF8.GetString(data.ToArray());

                    var request = new HttpRequest(requestAsString);
                    Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count} headers");

                    HttpResponse response;
                    var currentRoute = this.routeTable.FirstOrDefault(r => string.Compare(r.Path, request.Path, true) == 0 &&
                    r.Method == request.Method);
                    if (currentRoute != null)
                    {
                        response = currentRoute.Action(request); //Func which returns response

                    }
                    else
                    {
                        // Not Found 404
                        response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                    }

                    response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
                    { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });
                    response.Headers.Add(new Header("Server", "SUS Server 1.0"));

                    //var responseHtml = "<h1>Welcome!</h1>";
                    //var responseBody = Encoding.UTF8.GetBytes(responseHtml);
                    //var responseHttp = "HTTP/1.1 200 OK" + HttpConstants.NewLine +
                    //    "Server: SUS Server 1.0" + HttpConstants.NewLine +
                    //    "Content-Type: text/html" + HttpConstants.NewLine +
                    //    "Content-Length: " + responseBody.Length + HttpConstants.NewLine +
                    //    HttpConstants.NewLine;

                    var responseHeader = Encoding.UTF8.GetBytes(response.ToString());

                    await stream.WriteAsync(responseHeader, 0, responseHeader.Length);
                    await stream.WriteAsync(response.Body, 0, response.Body.Length);

                }

                tcpClient.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
