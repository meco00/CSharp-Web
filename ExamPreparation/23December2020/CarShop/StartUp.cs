using CarShop.Data;
using CarShop.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System;
using System.Threading.Tasks;

namespace CarShop
{
   public class StartUp
    {
        public static async Task Main(string[] args)
        => await HttpServer
            .WithRoutes(routes => routes
            .MapStaticFiles()
            .MapControllers())
            .WithServices(services => services
            .Add<IViewEngine, CompilationViewEngine>()
            .Add<ApplicationDbContext>()
            .Add<IValidatorService,ValidatorService>()
            .Add<IUserService,UserService>()
            .Add<IPasswordService,PasswordService>())
            .WithConfiguration<ApplicationDbContext>(context=> 
            context.Database.Migrate())
            .Start();
    }
}
