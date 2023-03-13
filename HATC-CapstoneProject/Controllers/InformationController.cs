using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HATC_CapstoneProject.Controllers
{
    public class InformationController : Controller
    {
		public IActionResult Index()
        {
            return View();
        }
    }
}
