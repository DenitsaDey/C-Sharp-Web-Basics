namespace SulsApp.Controllers
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
}