using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrivatSchoolsAPI.Infrastructure.Identity;

namespace PrivatSchoolsAPI.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string Username { get; set; }
        public string Email { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Username = user?.UserName;
            Email = user?.Email;
        }
    }
}
