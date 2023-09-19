using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesRazorApp.Data.Models;

namespace MoviesRazorApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginViewModel _loginViewModel { get; set; }
        private SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
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

            var i = _loginViewModel.RememberMe;

            var result = _signInManager.PasswordSignInAsync(
                    _loginViewModel.EmailAddress,
                    _loginViewModel.Password,
                    _loginViewModel.RememberMe, 
                false)
                .Result;

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return Page();
            }

            

            return RedirectToPage("Movies");
        }

       
        public IActionResult OnPostLogout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToPage("/Login");
        }
    }
}
