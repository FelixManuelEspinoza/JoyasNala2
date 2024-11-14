using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using JoyasNala.Data;
using JoyasNala.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JoyasNala.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;

        public LoginModel(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
            }
            return Page();
        }
    }
}
