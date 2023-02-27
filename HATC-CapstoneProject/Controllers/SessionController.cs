using Microsoft.AspNetCore.Mvc;

namespace HATC_CapstoneProject.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
