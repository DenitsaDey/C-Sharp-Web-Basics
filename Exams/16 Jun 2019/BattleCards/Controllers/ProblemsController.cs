<<<<<<< HEAD
﻿using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Controllers
{
    public class ProblemsController : Controller
    {
        public HttpResponse Create()
        {
            return this.View();
        }

        public HttpResponse Details()
        {
            return this.View();
        }
    }
}
=======
﻿using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if(string.IsNullOrEmpty(name) || 
                name.Length < 5 ||
                name.Length > 20)
            {
                return this.Error("Name should be between 5 and 20 characters.");
            }

            if(points < 50 || points > 300)
            {
                return this.Error("Points should be between 50 and 300.");
            }

            this.problemsService.Create(name, points);
            return this.Redirect("/");
        }
        public HttpResponse Details(string id)
        {
            var viewModel = this.problemsService.GetById(id);
            return this.View(viewModel);
        }
    }
}
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
