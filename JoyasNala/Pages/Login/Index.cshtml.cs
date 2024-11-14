using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using JoyasNala.Models;
using System.Threading.Tasks;

namespace JoyasNala.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        [BindProperty]
        public string Nombre { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByNameAsync(Nombre);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index"); // Redirecciona a la página principal
                }
            }
            ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
            return Page();
        }
    }
}
