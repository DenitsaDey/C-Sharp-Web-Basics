namespace SulsApp.Controllers
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
}