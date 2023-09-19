using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesRazorApp.Data.Models;
using MoviesRazorApp.Services;

namespace MoviesRazorApp.Pages
{
    public class MoviesModel : PageModel
    {
        public List<Movie> Movies { get; set; }

        private readonly IMoviesService _moviesService;

        public MoviesModel(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        public void OnGet()
        {
            Movies =_moviesService.GetAll();
        }
    }
}
