using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesRazorApp.Data.Models;
using MoviesRazorApp.Services;

namespace MoviesRazorApp.Pages
{
    public class MovieModel : PageModel
    {
        public Movie? Movie { get; set; }
        private readonly IMoviesService _moviesService;

        public MovieModel(IMoviesService moviesService)
        {
           _moviesService = moviesService;
        }
        public void OnGet(int id)
        {
               Movie=_moviesService.Get(id);
        }
    }
}
