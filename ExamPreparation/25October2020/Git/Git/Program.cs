namespace Git
{
    using Git.Data;
    using Git.Services;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using System.Threading.Tasks;

    

    public class Program
    {
       
        public static async Task Main(string[] args)
          => await HttpServer
            .WithRoutes(routes => routes
            .MapStaticFiles()
            .MapControllers())
            .WithServices(services => services
            .Add<IViewEngine, CompilationViewEngine>()
            .Add<IPasswordHasher,PasswordHasher>()
            .Add<IValidator,Validator>()
            .Add<ApplicationDbContext>())
            .WithConfiguration<ApplicationDbContext>(context =>
            context.Database.Migrate())
            .Start();


    }
}
