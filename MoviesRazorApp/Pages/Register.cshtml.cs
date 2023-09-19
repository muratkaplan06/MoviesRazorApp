using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesRazorApp.Data.Models;

namespace MoviesRazorApp.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel _registerModel { get; set; }
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
            var newUser= new IdentityUser
            {
                Email = _registerModel.EmailAddress,
                UserName = _registerModel.EmailAddress
            };
            var result = _userManager.CreateAsync(newUser, _registerModel.Password).Result;

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors.Select(x=>x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                return Page();
            }

            return RedirectToPage("Login");
        }
    }
}
