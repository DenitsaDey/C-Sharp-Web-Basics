using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
            //2. we created a View method in the parent class Controller that generates response
            //var responseHtml = File.ReadAllText("Controllers/Views/Users/Login.html");
            ////var responseHtml = "<h1>Login...</h1>"; - 1. instead we link it to an html file in Views/Users
            //var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            //var response = new HttpResponse("text/html", responseBodyBytes);
            //return response;
        }
        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
            //var responseHtml = File.ReadAllText("Controllers/Views/Users/Register.html");
            ////var responseHtml = "<h1>Register...</h1>";
            //var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            //var response = new HttpResponse("text/html", responseBodyBytes);
            //return response;
        }
    }
}
