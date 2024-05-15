using Bibliotekarz.Server.Data.Context;
using Library.Server.Databases.Contexts;
using Library.Server.Services;
using LibraryVue.Server.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace LibraryVue.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            //var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

            builder.Services.AddServices(builder.Configuration,
            builder.Environment);


            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();


            Logger logger;
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            }
            else
            {

                logger = NLog.LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

            }

            using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BooksDbContext>();
                context.Database.Migrate();
                var context2 = serviceScope.ServiceProvider.GetService<UsersDbContext>();
                context2.Database.Migrate();
            }

            logger.Debug("Init");
            app.UseHttpsRedirection();


            app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            ) ;


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
