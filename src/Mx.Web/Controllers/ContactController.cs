using Microsoft.AspNetCore.Mvc;

namespace Mx.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}