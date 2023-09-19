using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesRazorApp.Data.Models;
using MoviesRazorApp.Services;

namespace MoviesRazorApp.Pages
{
    [Authorize]
    public class AddMovieModel : PageModel
    {
        //[BindProperty]
        //public string Title { get; set; }
        //[BindProperty]
        //public int Rate { get; set; }
        //[BindProperty]
        //public string Description { get; set; }

        //public void OnGetMyOnClick()
        //{
        //    string value = "stop";
        //}
        [BindProperty]
        public Movie Movie { get; set; }

        private readonly IMoviesService _moviesService;
        public AddMovieModel(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public void OnGetMyOnClick()
        {
            string value = "stop";
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var movie = new Movie()
            {
                Title = Movie.Title,
                Rate = Movie.Rate,
                Description = Movie.Description
            };
            _moviesService.Add(movie);

            return RedirectToPage("Movies");
        }
    }
}
