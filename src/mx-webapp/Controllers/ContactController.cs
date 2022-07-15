using Microsoft.AspNetCore.Mvc;

namespace Mx.WebApp.Controllers
{
    public class ContactController : Controller
    {
        [Route("contact")]
        public IActionResult Index()
        {
            return View();
        }
    }
}