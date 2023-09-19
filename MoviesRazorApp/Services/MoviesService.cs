using MoviesRazorApp.Data;
using MoviesRazorApp.Data.Models;

namespace MoviesRazorApp.Services
{
    public class MoviesService:IMoviesService
    {
        private readonly ApplicationDbContext _context;

        public MoviesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie? Get(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}
