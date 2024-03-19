using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LibraryVue.Server.Models.Auth;

namespace Library.Server.Databases.Contexts
{
    public class UsersDbContext : IdentityDbContext<ApplicationUser>
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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-74V2UDI;Password=;Initial Catalog=LibraryUsers2;Integrated Security=True;Encrypt=False");

            return new UsersDbContext(optionsBuilder.Options);
        }

    }
}
