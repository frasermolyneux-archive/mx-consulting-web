using Microsoft.AspNetCore.Mvc;

namespace Mx.WebApp.Controllers
{
    public class AboutController : Controller
    {
        [Route("about")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("qualifications")]
        public IActionResult Qualifications()
        {
            return View();
        }

        [Route("profile")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}