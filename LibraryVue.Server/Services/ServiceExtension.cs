using Bibliotekarz.Server.Data.Context;
using Bibliotekarz.Server.Services;
using Library.Server.Controllers;
using Library.Server.Databases.Contexts;
using LibraryVue.Server.Models.Auth;
using LibraryVue.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System;
using System.Diagnostics.Metrics;
using System.Text;

namespace Library.Server.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration Configuration, IWebHostEnvironment environment)
        {

            // Database
            
            services.AddDbContext<BooksDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BookDB"))
                );
            services.AddDbContext<UsersDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserDB"))
                );

            var cos = Configuration.GetConnectionString("BookDB");
            cos = Configuration.GetConnectionString("UserDB");


            services.AddScoped<IBookDatabaseService, BookDatabaseService>();

            services.AddDbContext<UsersDbContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IServerFileService, ServerFileService>();


            // Adding Authentication
            services.
            AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidAudience = Configuration["JWT:ValidAudience"],
                     ValidIssuer = Configuration["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
                     ValidateIssuer= false,
                     ValidateAudience= false,
                     ValidateIssuerSigningKey= false,
                     ValidateLifetime= false,
                 };
             });
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.User, policy => policy.RequireRole(UserRoles.User));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            return services;
        }
    }
}
