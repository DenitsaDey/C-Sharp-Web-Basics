namespace SulsApp
{
    using System.Collections.Generic;
    using SulsApp.Data;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            //var db = new ApplicationDbContext();
            //db.Database.Migrate();
            //Console.WriteLine("Database migrated successfully");
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            
        }
    }
}
