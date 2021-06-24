

using CarShop.Data;
using CarShop.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System.Threading.Tasks;

namespace CarShop
{
    public static class Program
    {
        public static async Task Main(string[] args)
         => await HttpServer
            .WithRoutes(routes => routes
            .MapStaticFiles()
            .MapControllers())
            .WithServices(services => services
            .Add<IViewEngine, CompilationViewEngine>()
            .Add<IPasswordHasher, PasswordHasher>()
            .Add<IValidator, Validator>()
            .Add<IUsersService,UsersService>()
            .Add<ICarsService,CarsService>()
            .Add<IIssuesService,IIssuesService>()
            .Add<ApplicationDbContext>())
            .WithConfiguration<ApplicationDbContext>(context =>
            context.Database.Migrate())
            .Start();
    }
}
