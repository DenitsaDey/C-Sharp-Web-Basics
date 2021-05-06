using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //when we are client
            //await ReadData();

            //when we are server:
            Console.OutputEncoding = Encoding.UTF8;
            const string NewLine = "\r\n"; //new line stadart in http
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];//4096 is the size of each segment of the stream (each buffer)
                    var length = stream.Read(buffer, 0, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer, 0, length);
                    Console.WriteLine(requestString);


                    string html = $"<h1>Hello from DeniServer {DateTime.Now}</h1>" +
                        $"<form action=/tweet method=post><input name=username /><input name=password />" +
                        $"<input type=submit /></form>"; // creating form where method should be post

                    string response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: DeniServer 2020" + NewLine +
                        //"Location: https://www.google.com" + NewLine + //(instead of 200 OK put 307 Redirect)
                        "Content-Type: text/html; charset=utf-8" + NewLine + //content type can be image/png or text/plain or application/xml etc (can be found in MIME types search)
                        // "Content-Disposition: attachment; filename=deni.txt" + NewLine + // saves the content as file rather than displayig it
                        "Content-Lenght: " + html.Length + NewLine +
                        NewLine +
                        html + NewLine;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);


                    Console.WriteLine(new string('-', 70));
                }
            }
            
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/modules/108/csharp-web/1285";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x=>x.Key + ": " + x.Value.First())));

            //the same as web browser when pressing CTRL + U
            //var html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html);
        }

        
    }
}
