using Bibliotekarz.Server.Data.Context;
using Library.Server.Services;
using LibraryVue.Server.Models.Auth;
using Microsoft.EntityFrameworkCore;
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

            

            builder.Services.AddServices(builder.Configuration);

            var logger = NLog.LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

            logger.Debug("Init");

            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
/*
            using (IServiceScope scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<BooksDbContext>().Database.Migrate();
            }
*/
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            ) ;

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
