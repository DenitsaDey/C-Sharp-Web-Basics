namespace SulsApp
{
    using System.Collections.Generic;
    using SulsApp.Data;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using Microsoft.EntityFrameworkCore;
    using SulsApp.Services;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();
            Console.WriteLine("Database migrated successfully");
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}
