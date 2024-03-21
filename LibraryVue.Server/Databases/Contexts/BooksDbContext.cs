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

        public BooksDbContext(DbContextOptions<BooksDbContext> dbContextOptions) : base(dbContextOptions) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
