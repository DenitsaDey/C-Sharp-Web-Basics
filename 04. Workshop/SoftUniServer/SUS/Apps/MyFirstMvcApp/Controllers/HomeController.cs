﻿using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();

            //var responseHtml = "<h1>Welcome!</h1>" +
            //    request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            //var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            //var response = new HttpResponse("text/html", responseBodyBytes);
            //return response;
        }
        
    }
}
