using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Controllers
{
    public class SubmissionsController : Controller
    {
        public HttpResponse Create()
        {
            return this.View();
        }
    }
}
