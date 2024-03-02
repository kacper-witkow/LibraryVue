using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bibliotekarz.Shared.Model;
using Microsoft.EntityFrameworkCore.Design;

namespace Library.Server.Databases.Contexts
{
    public class UsersDbContext : IdentityDbContext<RegisterModel>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer($"Data Source=DESKTOP-74V2UDI;Initial Catalog=LibraryUsers;Integrated Security=True;Encrypt=False");


    }
    public class YourDbContextFactory : IDesignTimeDbContextFactory<UsersDbContext>
    {
        public UsersDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-74V2UDI;Initial Catalog=LibraryUsers2;Integrated Security=True;Encrypt=False");

            return new UsersDbContext(optionsBuilder.Options);
        }

    }
}
