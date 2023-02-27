using Microsoft.AspNetCore.Mvc;

namespace HATC_CapstoneProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
