using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";
        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public HttpHeaderCollection Headers{ get; private set; }

        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(NewLine);

            var startLine = lines.First().Split(" ");

            var method = ParseHttpRequestMethod(startLine[0]);
            var url = startLine[1];

            var headers = ParseHttpHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();
            var body = string.Join(NewLine, bodyLines);

            return new HttpRequest
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
        }


        private static HttpRequestMethod ParseHttpRequestMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpRequestMethod.Get,
                "POST" => HttpRequestMethod.Post,
                "PUT" => HttpRequestMethod.Put,
                "DELETE" => HttpRequestMethod.Delete,
                _ => throw new InvalidOperationException($"Method '{method}' is not supported."),
            };
        }

        private static HttpHeaderCollection ParseHttpHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                if(headerParts < 0)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }
                var header = new HttpHeader
                {
                    Name = headerLine.Substring(0, headerParts),
                    Value = headerLine[(headerParts + 1)..].Trim()
                };

                headerCollection.Add(header);
            }

            return headerCollection;
        }
        //private static string[] GetStartLine(string request)
        //{

        //}
    }
}
