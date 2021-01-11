using Microsoft.EntityFrameworkCore;
using MySulsExam.Data;
using MySulsExam.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace MySulsExam
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}