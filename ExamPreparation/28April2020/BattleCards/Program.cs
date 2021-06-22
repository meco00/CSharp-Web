
using BattleCards.Data;
using BattleCards.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System;
using System.Threading.Tasks;

namespace BattleCards
{
    public static class Program
    {
        public static async Task Main()
        => await HttpServer
            .WithRoutes(routes => routes
            .MapStaticFiles()
            .MapControllers())
            .WithServices(services => services
            .Add<IViewEngine, CompilationViewEngine>()
            .Add<IPasswordHasher, PasswordHasher>()
            .Add<IValidator, Validator>()
            .Add<ApplicationDbContext>())
            .WithConfiguration<ApplicationDbContext>(context =>
            context.Database.Migrate())
            .Start();
    }
}
