using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HATC_CapstoneProject.Controllers
{
    public class PlayerController : Controller
    {
		[Authorize(Roles = "DM")]
		public IActionResult Index()
        {
            return View();
        }
    }
}
