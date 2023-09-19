using MoviesRazorApp.Data.Models;

namespace MoviesRazorApp.Services
{
    public interface IMoviesService
    {
        List<Movie> GetAll();
        Movie? Get(int id);
        void Add(Movie movie);
    }
}
