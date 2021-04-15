using Microsoft.AspNetCore.Mvc;

namespace Mx.Web.Controllers
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