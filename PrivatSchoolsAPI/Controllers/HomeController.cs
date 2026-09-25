using Microsoft.AspNetCore.Mvc;

namespace PrivatSchoolsAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}