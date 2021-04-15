using System.Diagnostics;
using System.IO;
using CMCS.Common.WebUtilities.Objects;
using CMCS.Common.WebUtilities.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mx.Web.Models;

namespace Mx.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<UrlConfig> _urlConfig;

        public HomeController(
            ILogger<HomeController> logger,
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
            IOptions<UrlConfig> urlConfig)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            _urlConfig = urlConfig;
            _logger = logger;
        }

        [Route("")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [Route("sitemap.xml")]
        public IActionResult Sitemap()
        {
            var sitemapSvc = new SitemapService();
            var doc = sitemapSvc.GenerateSitemap(
                _actionDescriptorCollectionProvider.ActionDescriptors,
                _urlConfig.Value);

            using (var stream = new MemoryStream())
            {
                doc.Save(stream);
                return File(stream.ToArray(), "text/xml");
            }
        }
    }
}