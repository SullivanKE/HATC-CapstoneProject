using Microsoft.AspNetCore.Mvc;

namespace HATC_CapstoneProject.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
