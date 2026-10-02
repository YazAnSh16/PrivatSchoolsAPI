using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrivatSchoolsAPI.Infrastructure.Identity;

namespace PrivatSchoolsAPI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Phone]
            public string Phone { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByNameAsync(Input.Phone);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                ModelState.AddModelError(string.Empty, "If the account exists, a reset link will be provided.");
                return Page();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // For demo/dev: redirect to ResetPassword page with token in query string
            return RedirectToPage("/Account/ResetPassword", new { phone = Input.Phone, token });
        }
    }
}
