using Bibliotekarz.Server.Data.Context;
using Bibliotekarz.Server.Services;
using Library.Server.Databases.Contexts;
using NLog;

namespace Library.Server.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            // Database
            services.AddDbContext<BooksDbContext>();

            services.AddDbContext<UsersDbContext>();
            services.AddScoped<IBookDatabaseService, BookDatabaseService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            services.AddControllers();
            return services;
        }
    }
}
