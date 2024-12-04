using Microsoft.EntityFrameworkCore;
using MLG_Task.Model;

namespace MLG_Task.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        //  public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

         public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MLGTaks;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        //}

    }
}
