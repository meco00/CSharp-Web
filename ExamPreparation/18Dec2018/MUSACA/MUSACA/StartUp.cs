using Microsoft.EntityFrameworkCore;
using MUSACA.Data;
using MUSACA.Services;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System;
using System.Threading.Tasks;

namespace MUSACA
{
   public class StartUp
    {
       public static async Task Main(string[] args)
        =>  await HttpServer
            .WithRoutes(routes => routes
            .MapStaticFiles()
            .MapControllers())
            .WithServices(services => services
            .Add<IViewEngine, CompilationViewEngine>()
            .Add<ApplicationDbContext>()
            .Add<IValidatorService, ValidatorService>()
            .Add<IUserService, UserService>()
            .Add<IPasswordHasher, PasswordHasher>())
            .WithConfiguration<ApplicationDbContext>(context =>
            context.Database.Migrate())
            .Start();
    }
}
