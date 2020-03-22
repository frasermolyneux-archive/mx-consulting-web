using Microsoft.AspNetCore.Mvc;

namespace Mx.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Qualifications()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}