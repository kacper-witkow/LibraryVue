using Bibliotekarz.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Server.Data.Context
{
    public class BooksDbContext : DbContext
    {

        public DbSet<BookDto> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer($"Data Source=DESKTOP-74V2UDI;Initial Catalog=Library;Integrated Security=True;Encrypt=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
