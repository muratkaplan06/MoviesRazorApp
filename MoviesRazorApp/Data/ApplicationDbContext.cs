using Microsoft.EntityFrameworkCore;
using MoviesRazorApp.Data.Models;

namespace MoviesRazorApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
