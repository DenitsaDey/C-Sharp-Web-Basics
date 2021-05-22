<<<<<<< HEAD
﻿namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.ViewModels.Problems;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
          
            if (this.IsUserLoggedIn())
            {
                return this.View(new List<HomePageProblemViewModel>(), "IndexLoggedIn");
            }
            return this.View();
        }
    }
=======
﻿namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.Services;
    using SulsApp.ViewModels.Problems;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }
        [HttpGet("/")]
        public HttpResponse Index()
        {
          
            if (this.IsUserLoggedIn())
            {
                return this.View(this.problemsService.GetAll(), "IndexLoggedIn");
            }
            return this.View();
        }
    }
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
}