using Microsoft.AspNetCore.Mvc;

namespace HATC_CapstoneProject.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
